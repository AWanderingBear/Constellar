using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public GameObject Constellation1;
    public GameObject Constellation2;
    public GameObject Constellation3;
    public GameObject Constellation4;
    public GameObject Constellation5;
    public GameObject Constellation6;
    public GameObject Constellation7;
    public GameObject Constellation8;
    public GameObject Constellation9;
    public GameObject Constellation10;


    private LevelManager levelManager;
    public int CurrentLevel;

    // Use this for initialization
    void Start()
    {

        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        retrieveCurrentLevel();
        Debug.Log("Current level: " + CurrentLevel);
        if (CurrentLevel == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            CurrentLevel = 1;
            PlayerPrefs.Save();
        }

        if (CurrentLevel >= 1)
        {
            Constellation1.SetActive(true);
        }

        if (CurrentLevel >= 2)
        {
            Constellation2.SetActive(true);
        }

        if (CurrentLevel >= 3)
        {
            Constellation3.SetActive(true);
        }

        if (CurrentLevel >= 4)
        {
            Constellation4.SetActive(true);
        }

        if (CurrentLevel >= 5)
        {
            Constellation5.SetActive(true);
        }

        if (CurrentLevel >= 6)
        {
            Constellation6.SetActive(true);
        }

        if (CurrentLevel >= 7)
        {
            Constellation7.SetActive(true);
        }

        if (CurrentLevel >= 8)
        {
            Constellation8.SetActive(true);
        }

        if (CurrentLevel >= 9)
        {
            Constellation9.SetActive(true);
        }

        if (CurrentLevel >= 10)
        {
            Constellation10.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevel(int ConstellationID)
    {

            SceneManager.LoadScene(ConstellationID);
    }

    public void retrieveCurrentLevel()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();

        for (int i = 0; i < levelManager.levelComplete.Length; i++)
        {
            if (levelManager.levelComplete[i] == true)
            {
                PlayerPrefs.SetInt("Level", i + 1);
                CurrentLevel = i + 1;
            }
        }
    }
}
