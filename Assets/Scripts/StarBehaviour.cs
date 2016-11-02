using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour
{
    public GameObject StarObject;
    public GameManager.StarType starType;
    public StarManager starLinkManager;  //Handle to the starlink manager.
    public bool alreadyLinked;
    public bool mouseHeld;
    public bool earlyRelease;
    private bool alreadySplit;

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
                    Debug.Log("Normal Star");
                    BasicBehaviour();
                    break;
                case GameManager.StarType.NoCol:
                    Debug.Log("No Collision Star");
                    NoCollisionBehaviour();
                    break;
                case GameManager.StarType.Aura:
                    Debug.Log("Aura Star");
                    AuraBehaviour();
                    break;
                case GameManager.StarType.Split:
                    Debug.Log("Splitting Star");
                    SplitBehaviour(this);
                    break;
            }
        }
    }

    // Processes star linking when mouse is down
    void OnMouseDown()
    {
        starLinkManager.StartLineDrawing(this);
        earlyRelease = false;
        Debug.Log("Mouse click");
    }

    // When mouse is being held, return true
    void OnMouseDrag()
    {
        mouseHeld = true;
        
    }

    // When mouse is released
    void OnMouseUp()
    {       
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            StarBehaviour star = hit.collider.gameObject.GetComponent<StarBehaviour>();
            if (hit.collider.tag == "Star" && star.alreadyLinked == false)
            {
                starLinkManager.ProcessStarLinking(star);
            }
        }
        else
        {
            mouseHeld = false;
            earlyRelease = true;
        }
    }

    // Basic star behaviour
    void BasicBehaviour()
    {

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
            GameObject CloneOne = Instantiate(StarObject, gameObject.transform.GetChild(0).position, Quaternion.identity) as GameObject;
            GameObject CloneTwo = Instantiate(StarObject, gameObject.transform.GetChild(1).position, Quaternion.identity) as GameObject;
            GameObject CloneThree = Instantiate(StarObject, gameObject.transform.GetChild(2).position, Quaternion.identity) as GameObject;

            CloneOne.transform.parent = gameObject.transform;
            CloneTwo.transform.parent = gameObject.transform;
            CloneThree.transform.parent = gameObject.transform;

            currentStar.alreadySplit = true;
            
        }
    }

    // Star mechanic 3
    // A star that allows players to not collide with lines when jumping off of it
    // Ignore line colliders (Amberoni)
    void NoCollisionBehaviour()
    {

    }

    // Particle effects (future)

}
 