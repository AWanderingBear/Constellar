using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    public StarManager starLinkManager; //Handle to the starlink manager.

	// Use this for initialization
	void Start () {
        starLinkManager = GetComponentInParent<StarManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        starLinkManager.ProcessStarLinking(this);
        print("Star Clicked: " + name);
    }
}
