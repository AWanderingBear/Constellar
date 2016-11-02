using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int tempEnergy;
    public Text energyText;
    // Different types of stars
    public enum StarType
    {
        Normal,
        Aura,
        NoCol,
        Split
    };

    // Use this for initialization
    void Start () {
        tempEnergy = 100;
        energyText.text = "Current Energy: " + tempEnergy;
	}
	
	// Update is called once per frame
	void Update () {
        energyText.text = "Current Energy: " + tempEnergy;
        
    }
}
