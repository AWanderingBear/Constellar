using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkController : MonoBehaviour {

    public ParticleSystem[] DarkGenerators;

    float CurrentTime = 0;
    float LevelTime = 100;

	// Use this for initialization
	void Start () {

        DarkGenerators = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem Darkness in DarkGenerators)
        {

            ParticleSystem.MainModule Mod = Darkness.main;
            Mod.startLifetime = 1.0f;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        CurrentTime += Time.deltaTime;

        float DarknessTime = 1 + (4 * CurrentTime / LevelTime);

        foreach (ParticleSystem Darkness in DarkGenerators)
        {

            ParticleSystem.MainModule Mod = Darkness.main;
            Mod.startLifetime = DarknessTime;
        }
    }
}
