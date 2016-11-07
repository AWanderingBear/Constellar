using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour
{
    public GameObject StarObject;
    public GameManager.StarType starType;
    public StarManager starLinkManager;  //Handle to the starlink manager.
    public bool alreadyLinked = false;
    public bool mouseHeld;
    public bool earlyRelease;
    private bool alreadySplit;
    private float downTime;
    Ray ray;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        starLinkManager = GetComponentInParent<StarManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Checks for mouse click on stars
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (starType)
            {
                case GameManager.StarType.Normal:
                    Debug.Log("Clicked a Normal Star");
                    //Debug.Log(alreadyLinked);
                    break;
                case GameManager.StarType.NoCol:
                    Debug.Log("Clicked a No Collision Star");
                    //Debug.Log(alreadyLinked);
                    break;
                case GameManager.StarType.Aura:
                    Debug.Log("Clicked a Aura Star");
                    //Debug.Log(alreadyLinked);
                    AuraBehaviour();
                    break;
                case GameManager.StarType.Split:
                    Debug.Log("Clicked a Splitting Star");
                    //Debug.Log(alreadyLinked);
                    //SplitBehaviour(this);
                    break;
            }
        }
    }

    // Processes star linking when mouse is down
    void OnMouseDown()
    {
        starLinkManager.StartLineDrawing(this);
        earlyRelease = false;
        
    }

    // When mouse is being held, return true
    void OnMouseDrag()
    {
        mouseHeld = true;
        downTime += Time.deltaTime;

        if (downTime > 0.2f)
        {
            starLinkManager.drawing = true; 
        }
    }

    // When mouse is released
    void OnMouseUp()
    {
        // Turn mouse held boolean off
        mouseHeld = false;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            StarBehaviour star = hit.collider.gameObject.GetComponent<StarBehaviour>();

            if ((hit.collider.tag == "Star" || hit.collider.tag == "Planet") && !star.alreadyLinked && starLinkManager.drawing)
            {

                // if the star is a splitting star
                if (star.starType == GameManager.StarType.Split)
                {
                    SplitBehaviour(star);
                }

                starLinkManager.ProcessStarLinking(star);
                starLinkManager.firstSelected = true;          
            }

            else if (star.alreadyLinked)
                {
                    earlyRelease = true;
                }
        }
        else
        {    
            earlyRelease = true;
        }

        if (downTime < 0.2f)
        {
            earlyRelease = true;
        }

        // reset timer
        downTime = 0.0f;
    }


    // Star mechanic 1
    // A star with an aura that drives away darkness and inside which jumping costs nothing
    void AuraBehaviour()
    {
        // Go away darkness!
    }

    // Star mechanic 2
    // A star that creates more stars when attached to that are signalled at all times
    void SplitBehaviour(StarBehaviour currentStar)
    {
        if (!currentStar.alreadySplit)
        {
            GameObject CloneOne = Instantiate(StarObject, currentStar.transform.GetChild(0).position, Quaternion.identity) as GameObject;
            GameObject CloneTwo = Instantiate(StarObject, currentStar.transform.GetChild(1).position, Quaternion.identity) as GameObject;
            GameObject CloneThree = Instantiate(StarObject, currentStar.transform.GetChild(2).position, Quaternion.identity) as GameObject;

            CloneOne.transform.parent = currentStar.transform;
            CloneTwo.transform.parent = currentStar.transform;
            CloneThree.transform.parent = currentStar.transform;

            currentStar.alreadySplit = true;
            
        }
    }
}
 