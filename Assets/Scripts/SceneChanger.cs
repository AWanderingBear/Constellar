using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    IEnumerator Fading()
    {
        float fadeTime = GameObject.Find("Game Manager").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }


    public void SceneLoad(string SceneName)
    {
        Fading();
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
