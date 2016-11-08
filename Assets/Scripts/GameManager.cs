using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int tempEnergy = 100;
    public Text energyText;
    // Different types of stars
    public enum StarType
    {
        Normal,
        Aura,
        NoCol,
        Split,
        Goal
    };

    // Use this for initialization
    void Start () {
        energyText.text = "Current Energy: " + tempEnergy;
	}
	
	// Update is called once per frame
	void Update () {
        energyText.text = "Current Energy: " + tempEnergy;
        
        if (Input.GetKeyDown("r"))
        {
            gameObject.GetComponent<SceneChanger>().restartScene();
        }
    }
  
}
