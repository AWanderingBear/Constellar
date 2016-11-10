using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeButton : MonoBehaviour {

    public Sprite VolumeOn;
    public Sprite VolumeOff;

    bool VolumeActive = true;
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

        SwapIcon();
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

    public void SwapIcon()
    {

        if (VolumeActive)
        {
            Renderer.sprite = VolumeOff;
            VolumeActive = false;
        }
        else
        {
            Renderer.sprite = VolumeOn;
            VolumeActive = true;
        }
    }
}
