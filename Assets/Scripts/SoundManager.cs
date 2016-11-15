using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour {

    public AudioSource themeSource;
    public AudioSource efxSource;

    public AudioClip mainTheme;
    public AudioClip[] starClicks;

    public static SoundManager instance = null;

    // Use this for initialization
    void Awake () {

        efxSource = GameObject.Find("Audio Manager").GetComponent<AudioSource>();
        themeSource = GameObject.Find("Audio Manager").GetComponent<AudioSource>();

        themeSource.PlayOneShot(mainTheme);

        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {

        ////Set the clip of our efxSource audio source to the clip passed in as a parameter.
        //efxSource.clip = clip;

        //Play the clip.
        efxSource.PlayOneShot(clip);
    }

    public void PlayStar()
    {
        int randomClick = Random.Range(0, starClicks.Length);
        AudioClip starClick = starClicks[randomClick];
        efxSource.PlayOneShot(starClick);
    }

}
