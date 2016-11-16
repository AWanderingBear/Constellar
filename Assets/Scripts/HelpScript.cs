using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour {

    public Text basicText;
    public Text goal;
    public Text Void;
    public Text nebula;
    public Text splitting;
    public Text aura;

    public GameManager.StarType starType;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instructions")
        {
            switch (starType)
            {
                case GameManager.StarType.Normal:
                    basicText.text = "A simple star you can connect to";
                    break;
                case GameManager.StarType.NoCol:
                    Void.text = "You can cross over lines from this star";
                    break;
                case GameManager.StarType.Aura:
                    aura.text = "This star creates light when connected! The light repels darkness!";
                    break;
                case GameManager.StarType.Split:
                    splitting.text = "This star splits into multiple stars when connected";
                    break;
                case GameManager.StarType.Goal:
                    goal.text = "You want to reach here to finish a level!";
                    break;
                case GameManager.StarType.Planet:
                    nebula.text = "Connect to this and you gain energy";
                    break;
            }
        }
    }

    void OnMouseExit()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Instructions")
        {
            switch (starType)
            {
                case GameManager.StarType.Normal:
                    basicText.text = "This is a basic star";
                    break;
                case GameManager.StarType.NoCol:
                    Void.text = "This is a void star";
                    break;
                case GameManager.StarType.Aura:
                    aura.text = "This is an aura star";
                    break;
                case GameManager.StarType.Split:
                    splitting.text = "This is a splitting star";
                    break;
                case GameManager.StarType.Goal:
                    goal.text = "This is a goal";
                    break;
                case GameManager.StarType.Planet:
                    nebula.text = "This is a nebula";
                    break;
            }
        }
    }
}
