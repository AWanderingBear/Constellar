﻿using System.Collections;
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

    private int CurrentLevel;

    // Use this for initialization
    void Start()
    {

        CurrentLevel = PlayerPrefs.GetInt("Level", 0);
        if (CurrentLevel == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
            CurrentLevel = 1;
            PlayerPrefs.Save();
        }

        if (CurrentLevel > 3)
        {

            Constellation2.SetActive(true);
        }
        else if (CurrentLevel > 6)
        {

            Constellation3.SetActive(true);
        }
        else if (CurrentLevel > 9)
        {

            Constellation4.SetActive(true);
        }
        else if (CurrentLevel > 12)
        {

            Constellation5.SetActive(true);
        }
        else if (CurrentLevel > 15)
        {

            Constellation6.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevel(int ConstellationID)
    {

        if (CurrentLevel > ConstellationID * 3 && CurrentLevel <= ConstellationID * 4)
        {

            SceneManager.GetSceneAt(CurrentLevel);
        }
        else if (CurrentLevel > ConstellationID * 3)
        {

            //Level Repeat
            //Set options
            //Send Level change
        }
    }
}