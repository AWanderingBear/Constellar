using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUpManager : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        float fadeTime = GameObject.Find("Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("Main Menu");

    }
}
