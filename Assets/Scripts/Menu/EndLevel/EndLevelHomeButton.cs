using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelHomeButton : MonoBehaviour
{

    bool Zoomed = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(0);
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
