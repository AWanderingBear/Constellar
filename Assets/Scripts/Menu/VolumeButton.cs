using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour {


    bool Zoomed = false;
    private SpriteRenderer Renderer;
    // Use this for initialization
    void Start () {

        Renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
    }

    void OnMouseOver()
    {
        if (!Zoomed)
        {
            Vector3 NewScale = transform.localScale;
            NewScale.x += 0.1f;
            NewScale.y += 0.1f;
            transform.localScale = NewScale;
            Zoomed = true; 
        }
    }

    void OnMouseExit()
    {
        if (Zoomed)
        {
            Vector3 NewScale = transform.localScale;
            NewScale.x -= 0.1f;
            NewScale.y -= 0.1f;
            transform.localScale = NewScale;
            Zoomed = false;
        }
    }
}
