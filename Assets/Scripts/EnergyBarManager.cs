using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarManager : MonoBehaviour {

    private LineRenderer lineRenderer;
    public Transform[] Points;
    List<Vector3> Position;

    public int Test;
    // Use this for initialization
    void Start () {

        lineRenderer = GetComponent<LineRenderer>();

        Points = GetComponentsInChildren<Transform>();

        Test = Points.Length;

        lineRenderer.numPositions = Points.Length;

        for (int i = 0; i < Points.Length; i++)
        {

            lineRenderer.SetPosition(i, Points[i].position);
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
