using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarBehaviour : MonoBehaviour
{
    // Star variables
    private StarBehaviour selectedStar;
    public StarBehaviour[] allStars;
    public GameObject StarObject;
    public GameManager.StarType starType;
    public LevelManager levelManager;

    public StarManager starLinkManager;  //Handle to the starlink manager.

    public SoundManager soundManager;

    private Text restartText;
    public string scene;

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
        soundManager = GameObject.Find("Audio Manager").GetComponent<SoundManager>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();

        restartText = GameObject.Find("RestartText").GetComponent<Text>();
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
                    break;
                case GameManager.StarType.Split:
                    Debug.Log("Clicked a Splitting Star");
                    //Debug.Log(alreadyLinked);
                    break;
                case GameManager.StarType.Goal:
                    Debug.Log("Clicked a Goal Star");
                    //Debug.Log(alreadyLinked);
                    break;
            }
        }
    }

    // Processes star linking when mouse is down
    void OnMouseDown()
    {
        starLinkManager.StartLineDrawing(this);
        earlyRelease = false;
        selectedStar = this;
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

        if (Physics.Raycast(ray, out hit) && selectedStar == starLinkManager.currentlySelectedStar)
        {
            StarBehaviour star = hit.collider.gameObject.GetComponent<StarBehaviour>();

            if ((hit.collider.tag == "Star" || hit.collider.tag == "Planet") && !star.alreadyLinked && starLinkManager.drawing)
            {
                starLinkManager.ProcessStarLinking(star);
                starLinkManager.firstSelected = true;

                if (soundManager != null)
                {
                    soundManager.PlayStar();
                }

                // if the star is a splitting star
                if (star.starType == GameManager.StarType.Split && !earlyRelease)
                {
                    SplitBehaviour(star);
                }
                // if the star is a goal star
                if (star.starType == GameManager.StarType.Goal && !earlyRelease)
                {
                    GoalBehaviour(star);
                }
                // if the star is a aura star
                if (star.starType == GameManager.StarType.Aura && !earlyRelease)
                {
                    AuraBehaviour(star);
                }

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
    void AuraBehaviour(StarBehaviour currentStar)
    {
        GameObject haloChild = currentStar.transform.GetChild(0).gameObject;
        Component halo = haloChild.GetComponent("Halo");
        currentStar.GetComponentInChildren<CircleCollider2D>().enabled = true;
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }

    // Star mechanic 2
    // A star that creates more stars when attached to that are signalled at all times
    void SplitBehaviour(StarBehaviour currentStar)
    {
        if (!currentStar.alreadySplit)
        { 
            GameObject CloneOne = Instantiate(Resources.Load("RegularStar"), currentStar.transform.GetChild(0).position, Quaternion.identity) as GameObject;
            GameObject CloneTwo = Instantiate(Resources.Load("RegularStar"), currentStar.transform.GetChild(1).position, Quaternion.identity) as GameObject;
            GameObject CloneThree = Instantiate(Resources.Load("RegularStar"), currentStar.transform.GetChild(2).position, Quaternion.identity) as GameObject;

            CloneOne.transform.parent = currentStar.transform;
            CloneTwo.transform.parent = currentStar.transform;
            CloneThree.transform.parent = currentStar.transform;


            currentStar.alreadySplit = true;

            currentStar.GetComponent<SpriteRend>().SwitchSprite(currentStar);
        }
    }

    void GoalBehaviour(StarBehaviour goalStar)
    {
        Scene scene = SceneManager.GetActiveScene();

        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        levelManager.tickLevelCompletion();

            goalStar.GetComponent<SceneChanger>().SceneLoad("End Level");

            // debug log for checking level completion boolean values
            //for (int i = 1; i < levelManager.numScenes; i++)
            //{
            //    Debug.Log("Levels completed: Level " + i + " " + levelManager.levelComplete[i]);
            //}
    
    }
}
