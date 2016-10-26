using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {

    public GameManager.StarType starType;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");

                switch (starType)
                {
                    case GameManager.StarType.Normal:
                        Debug.Log("Normal Star");
                        break;
                    case GameManager.StarType.NoCol:
                        Debug.Log("No Collision Star");
                        break;
                    case GameManager.StarType.Aura:
                        Debug.Log("Aura Star");
                        break;
            }
        }
    }
    // Star mechanic 1
    // A star with an aura that drives away darkness and inside which jumping costs nothing

    // Star mechanic 2
    // A star that creates more stars when attached to that are signalled at all times

    // Star mechanic 3
    // A star that allows players to not collide with lines when jumping off of it
    // Turn line collider off (Amberoni)
    // Particle effects (future)

}
