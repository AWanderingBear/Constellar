using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationHover : MonoBehaviour {

    public GameObject Context;
    public int ConstellationID = 0;
    private LevelSelectManager select;

	// Use this for initialization
	void Start () {

        select = GetComponentInParent<LevelSelectManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {

        Context.SetActive(true);
    }

    void OnMouseExit()
    {

        Context.SetActive(false);
    }

    void OnMouseDown()
    {
        select.GoToLevel(ConstellationID);
    }
}
