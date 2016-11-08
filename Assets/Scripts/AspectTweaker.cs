using UnityEngine;
using System.Collections;

public class AspectTweaker : MonoBehaviour {

    float defaultSize = 1.77f;
    Camera m_Camera;

	// Use this for initialization
	void Start () {

        m_Camera = GetComponent<Camera>();

        m_Camera.orthographicSize = defaultSize / m_Camera.aspect * m_Camera.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
