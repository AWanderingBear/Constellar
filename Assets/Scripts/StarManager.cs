using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

    public Star currentlySelectedStar;         //Gets chosen through starlink script after a star is clicked.
    public GameObject connectingLinePrefab;     //The connecting line. Sprite can be turned on or off.
    public GameObject LinkHolder;   //An empty defaut Gameobject to keep our heirarchy clean.

    private LineRenderer line;

    //  START OF THE CODE:
    public void ProcessStarLinking (Star _star)  //Called by the stars themselves onMouseDown. 
    {
        if (currentlySelectedStar == null)  //First Selected star.
        {
            currentlySelectedStar = _star;
            return;
        }
        else if (currentlySelectedStar == _star) //We already have this one selected, deselect it.
        {
            currentlySelectedStar = null;
            return;                     //Since we're only deselecting, we don't want to attempt a link.
        }
        else //Else we need to link.
        {
            AttemptCollisionLink(currentlySelectedStar, _star);
        }
    }

    void AttemptCollisionLink(Star _starOne, Star _starTwo)
    {

        currentlySelectedStar = null;

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
        Vector3 newLinePosition = new Vector3(minimumX + (differenceX/2.0f), minimumY + (differenceY/2.0f), 0.0f);

        //Finding the scale
        float connectionLength = Mathf.Sqrt((differenceX * differenceX) + differenceY * differenceY);


        //Create the Game Object
        GameObject newConnection = (GameObject) Instantiate(connectingLinePrefab, newLinePosition, rotationQuat);
        newConnection.transform.parent = LinkHolder.transform;
        
        //Set Scale
        newConnection.transform.localScale = new Vector3(connectionLength, 0.05f, 1.0f);


        //Create the Line Renderer
        line = newConnection.AddComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetWidth(0.05f, 0.05f);
        line.useWorldSpace = true;
        line.SetPosition(0, _starOne.transform.position);
        line.SetPosition(1, _starTwo. transform.position);
    }
}
