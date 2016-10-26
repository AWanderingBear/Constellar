using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour
{
    public GameObject StarObject;
    public GameManager.StarType starType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Checks for mouse click on stars
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");

            switch (starType)
            {
                case GameManager.StarType.Normal:
                    Debug.Log("Normal Star");
                    BasicBehaviour();
                    break;
                case GameManager.StarType.NoCol:
                    Debug.Log("No Collision Star");
                    NoCollisionBehaviour();
                    break;
                case GameManager.StarType.Aura:
                    Debug.Log("Aura Star");
                    AuraBehaviour();
                    break;
                case GameManager.StarType.Split:
                    Debug.Log("Splitting Star");
                    SplitBehaviour();
                    break;
            }
        }
    }

    // Basic star behaviour
    void BasicBehaviour()
    {

    }

    // Star mechanic 1
    // A star with an aura that drives away darkness and inside which jumping costs nothing
    void AuraBehaviour()
    {
        // Go away darkness!
    }

    // Star mechanic 2
    // A star that creates more stars when attached to that are signalled at all times
    void SplitBehaviour()
    {
        GameObject CloneOne = Instantiate(StarObject, gameObject.transform.GetChild(0).position, Quaternion.identity) as GameObject;
        GameObject CloneTwo = Instantiate(StarObject, gameObject.transform.GetChild(1).position, Quaternion.identity) as GameObject;
        GameObject CloneThree = Instantiate(StarObject, gameObject.transform.GetChild(2).position, Quaternion.identity) as GameObject;
    }

    // Star mechanic 3
    // A star that allows players to not collide with lines when jumping off of it
    // Ignore line colliders (Amberoni)
    void NoCollisionBehaviour()
    {

    }

    // Particle effects (future)

}
 