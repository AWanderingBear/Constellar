using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public bool[] levelComplete;

    public Scene scene;
    public int numScenes;

    public static LevelManager instance = null;


    void Start()
    {
        numScenes = SceneManager.sceneCountInBuildSettings;
        levelComplete = new bool[numScenes];

    }

    // Use this for initialization
    void Awake () {

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
        for (int i = 2; i <= numScenes; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                levelComplete[i - 1] = true;
            }
        }
    }
}
