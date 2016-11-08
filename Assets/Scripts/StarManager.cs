using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour
{

    public StarBehaviour currentlySelectedStar;         //Gets chosen through starlink script after a star is clicked.
    public GameObject connectingLinePrefab;     //The connecting line. Sprite can be turned on or off.
    public GameObject LinkHolder;   //An empty default Gameobject to keep our heirarchy clean.
    private GameObject tempConnection; // our line that is constantly drawing on mouse hold

    private LineRenderer line;
    private float rayLength = 100.0f;   //Way too long.
    private RaycastHit vision;

    public Vector3 mousePos;

    private bool drawRay;
    public bool firstSelected;
    private bool selected;
    public bool drawing;

    void Update()
    {
        if (selected)
        {
            // keep drawing and updating the line position if mouse if being held
            if (currentlySelectedStar.mouseHeld == true)
            {
                UpdateLine(currentlySelectedStar, mousePos);
            }

            // on early mouse release
            if (Input.GetMouseButtonUp(0) && currentlySelectedStar.earlyRelease)
            {
                if (!firstSelected)
                {
                    currentlySelectedStar = null;
                }
                selected = false;
                Destroy(tempConnection);
            }
        }

        // on mouse release
        if (Input.GetMouseButtonUp(0))
            {
                drawing = false;
            }

        if (drawRay == true)
        {
            Debug.DrawRay(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(99.0f, 99.0f, 0.0f), Color.red, 0.5f);
        }

        // We want the mouse position to always update every frame
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void ProcessStarLinking(StarBehaviour _star)  // Called by the stars themselves onMouseDown. 
    {
        if (currentlySelectedStar == null)  // First Selected star.
        {
            currentlySelectedStar = _star;
           
            return;
        }

        else //Else we need to link.
        {
            if (!_star.alreadyLinked)
            {
                AttemptLink(currentlySelectedStar, _star);
            }
            else
            {
                return;
            }

        }
    }

    public void StartLineDrawing(StarBehaviour _star)
    {
        if (currentlySelectedStar == null)
        {
            currentlySelectedStar = _star;
            
            selected = true;
            //Debug.Log("Selected star: " + currentlySelectedStar);
            DrawLine(currentlySelectedStar, mousePos);
            return;
        }

        else if (_star == currentlySelectedStar)
        {
            selected = true;
            DrawLine(currentlySelectedStar, mousePos);
            return;
        }

        else
        {
           return;
        }
    }


    void AttemptLink(StarBehaviour _starOne, StarBehaviour _starTwo)
    {
        //if raycast returns the star.
        Vector3 raycastDirection;
        raycastDirection = new Vector3(_starTwo.transform.position.x - _starOne.transform.position.x,
                                       _starTwo.transform.position.y - _starOne.transform.position.y, 0.0f);
        Vector3 firstStarPosition = new Vector3(_starOne.transform.position.x, _starOne.transform.position.y, 0.0f);
        Ray attemptedRay = new Ray(firstStarPosition, raycastDirection);

        Debug.DrawRay(_starOne.transform.position, raycastDirection * rayLength, Color.red, 0.5f);

        if (Physics.Raycast(attemptedRay, out vision, rayLength))
        {

            if (vision.collider.tag == "Star")
            {
                Debug.Log("Detected collision with: " + vision.collider.tag);
                drawRay = true;
                //Debug.Log("hit");
                LinkStars(_starOne, _starTwo);
                _starOne.alreadyLinked = true;
                _starTwo.alreadyLinked = true;
                // Energy cost to link to star
                GameManager.tempEnergy -= 10;
            }
            else if (vision.collider.tag == "Planet")
            {
                Debug.Log("Detected collision with: " + vision.collider.tag);
                drawRay = true;
                //Debug.Log("hit");
                LinkStars(_starOne, _starTwo);
                _starOne.alreadyLinked = true;
                _starTwo.alreadyLinked = true;
                // Energy gained linking to a planet
                GameManager.tempEnergy += 20;
            }

            // ignore collision if the star is a no collision star type
            else if (vision.collider.tag == "Line" && currentlySelectedStar.starType == GameManager.StarType.NoCol)
            {
                Debug.Log("Detected collision with: " + vision.collider.tag);
                drawRay = true;
                //Debug.Log("hit");
                LinkStars(_starOne, _starTwo);
                _starOne.alreadyLinked = true;
                _starTwo.alreadyLinked = true;
                GameManager.tempEnergy -= 10;
            }

            else
            {
                Debug.Log("Detected collision with: " + vision.collider.tag);
                currentlySelectedStar.earlyRelease = true;
            }

            if (_starTwo.alreadyLinked)
            {
                currentlySelectedStar.earlyRelease = true;
            }
        }
    }

    void LinkStars(StarBehaviour _starOne, StarBehaviour _starTwo)
    {
        // Star linked to the selected start will always be the starting point
        currentlySelectedStar = _starTwo;

        //Finding the distance vector
        float differenceX = (_starOne.transform.position.x - _starTwo.transform.position.x);
        float differenceY = (_starOne.transform.position.y - _starTwo.transform.position.y);

        //Finding the Line Z Angle        //SOH CAH --> TOA <--
        float angleZ = Mathf.Rad2Deg * Mathf.Atan((differenceY / differenceX));   //should give angle

        //The rest of the math relies on these both being positive.
        differenceX = Mathf.Abs(differenceX);
        differenceY = Mathf.Abs(differenceY);

        //Creating the final rotation Vec
        Quaternion rotationQuat = Quaternion.Euler(0.0f, 0.0f, angleZ);

        //Finding the Position - minimum x and y plus half of the distance between the two x's and y'x returns the middle of the game world vector.
        float minimumX = Mathf.Min(_starOne.transform.position.x, _starTwo.transform.position.x);
        float minimumY = Mathf.Min(_starOne.transform.position.y, _starTwo.transform.position.y);
        Vector3 newLinePosition = new Vector3(minimumX + (differenceX / 2.0f), minimumY + (differenceY / 2.0f), 0.0f);

        //Finding the scale
        float connectionLength = Mathf.Sqrt((differenceX * differenceX) + differenceY * differenceY);


        //Create the Game Object
        GameObject lineConnection = (GameObject)Instantiate(connectingLinePrefab, newLinePosition, rotationQuat);
        lineConnection.transform.parent = LinkHolder.transform;

        //Set Scale
        lineConnection.transform.localScale = new Vector3(connectionLength, 0.05f, 1.0f);


        //Create the Line Renderer
        line = lineConnection.AddComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetWidth(0.05f, 0.05f);
        line.useWorldSpace = true;
        line.SetPosition(0, _starOne.transform.position);
        line.SetPosition(1, _starTwo.transform.position);

        Destroy(tempConnection);
    }

    void DrawLine(StarBehaviour _starOne, Vector3 mousePos)
    {
        //Finding the distance vector
        float differenceX = (_starOne.transform.position.x - mousePos.x);
        float differenceY = (_starOne.transform.position.y - mousePos.y);

        //Finding the Line Z Angle        //SOH CAH --> TOA <--
        float angleZ = Mathf.Rad2Deg * Mathf.Atan((differenceY / differenceX));   //should give angle

        //The rest of the math relies on these both being positive.
        differenceX = Mathf.Abs(differenceX);
        differenceY = Mathf.Abs(differenceY);

        //Creating the final rotation Vec
        Quaternion rotationQuat = Quaternion.Euler(0.0f, 0.0f, angleZ);

        //Finding the Position - minimum x and y plus half of the distance between the two x's and y'x returns the middle of the game world vector.
        float minimumX = Mathf.Min(_starOne.transform.position.x, mousePos.x);
        float minimumY = Mathf.Min(_starOne.transform.position.y, mousePos.y);
        Vector3 newLinePosition = new Vector3(minimumX + (differenceX / 2.0f), minimumY + (differenceY / 2.0f), 0.0f);

        //Finding the scale
        float connectionLength = Mathf.Sqrt((differenceX * differenceX) + differenceY * differenceY);


        //Create the Game Object
       tempConnection = (GameObject)Instantiate(connectingLinePrefab, newLinePosition, rotationQuat);
        tempConnection.transform.parent = LinkHolder.transform;

        //Set Scale
        tempConnection.transform.localScale = new Vector3(connectionLength, 0.05f, 0);

        //Create the Line Renderer
        line = tempConnection.AddComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetWidth(0.05f, 0.05f);
        line.useWorldSpace = true;
        line.SetPosition(0, _starOne.transform.position);
        line.SetPosition(1, mousePos);
    }

    public void UpdateLine(StarBehaviour _starOne, Vector3 mousePos)
    {
        // Update the line renderer
        line.useWorldSpace = true;
        line.SetPosition(0, _starOne.transform.position);
        Vector3 tempPos = new Vector3(mousePos.x, mousePos.y, 1.0f);
        line.SetPosition(1, tempPos);
    }



}
