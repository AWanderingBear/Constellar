using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarResizer : MonoBehaviour {


    public StarManager starManager;
    public float barPercentage;
    // Use this for initialization
    void Start () {
     //   starManager = GameObject.Find("StarManager").GetComponent<StarManager>();             
            }
	
	// Update is called once per frame
	void Update () {
        if (barPercentage != starManager.totalLevelEnergyPercentageUsed)
        {
            barPercentage = Mathf.Lerp(barPercentage, starManager.totalLevelEnergyPercentageUsed, 0.5f);
        }
        
        GetComponent<RectTransform>().sizeDelta = new Vector2(barPercentage/2, 36.7f);

        //max = 50.0 width means bar percentage needs to be divided by 2.
        //Min = 0.0 width
	}
}
