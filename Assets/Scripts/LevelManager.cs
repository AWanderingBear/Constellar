using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool[] levelComplete;

    public Scene scene;
    public int numScenes;

    public static LevelManager instance = null;
    public LevelSelectManager levelSelectManager;

    public int numStarLinked;
    public int playerScore;
    public int timeElapsed;

    void Start()
    {
        numScenes = SceneManager.sceneCountInBuildSettings;
        levelComplete = new bool[numScenes];
        int stars = PlayerPrefs.GetInt("Stars Linked");
        float time = PlayerPrefs.GetFloat("Time Elapsed");
        Debug.Log("Stars: " + stars + "  " + "Time passed: " + time);
    }

    // Use this for initialization
    void Awake() {

        numScenes = SceneManager.sceneCountInBuildSettings;
        levelComplete = new bool[numScenes];


        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void tickLevelCompletion()
    {
        for (int i = 1; i <= numScenes; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                levelComplete[i] = true;
                PlayerPrefs.SetInt("LastLevelComplete", i);
                if (PlayerPrefs.GetInt("Level") < i){
                    PlayerPrefs.SetInt("Level", i);
                }
            }
        }
    }


}
