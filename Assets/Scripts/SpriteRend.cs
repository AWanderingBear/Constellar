using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteRend : MonoBehaviour {

    public Sprite borderStar;
    public Sprite basicStar;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SwitchSprite(StarBehaviour star)
    {
        if (star.GetComponent<SpriteRenderer>().sprite == borderStar)
        {
            Debug.Log("Hlelo");
            star.GetComponent<SpriteRenderer>().sprite = basicStar;
        }
    }
}
