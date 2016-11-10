using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    public Spinner Spinner;
    public Sprite Home;
    public Sprite Play;

    bool PlayActive = true;
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

        Spinner.Spin();
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

        if (PlayActive)
        {
            Renderer.sprite = Home;
            PlayActive = false;
        }
        else
        {
            Renderer.sprite = Play;
            PlayActive = true;
        }
    }
}
