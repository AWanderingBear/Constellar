using UnityEngine;
using System.Collections;

public class LightUI : MonoBehaviour {

    public Transform Top;
    public Transform Bottom;

    private LineRenderer Bar;

    Vector3[] BARPOS = new Vector3[2];

    // Use this for initialization
    void Start () {

        Bar = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        BARPOS[0] = Top.position;
        BARPOS[1] = Bottom.position;

        Bar.SetPositions(BARPOS);
	}
}
