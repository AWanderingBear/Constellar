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
        if (SceneName == "Exit")
        {
            Application.Quit();
        }

        else if (SceneName == "Level Five")
        {
            GameManager.tempEnergy = 10;
            Fading();
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            GameManager.tempEnergy = 100;
            Fading();
            SceneManager.LoadScene(SceneName);
        }
    }

    public void restartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameManager.tempEnergy = 100;
    }
}
