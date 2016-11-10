using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public Camera mainCamera;

    public GameObject playButton;
    public GameObject volumeButton;
    public GameObject settingButton;

    public float SpinTime = 2.0f;
    public float SpinPanDelay = 0.5f;

    private float CurrentSpinTime = 0.0f;
    private float PanPerTick;
    private float SpinPerTick;

    private bool Spinning = false;
    private bool LevelSelect = false;
    private bool IconFlip = false;

    private float LevelViewOffSet = 14.5f;

    // Use this for initialization
    void Start()
    {

        PanPerTick = LevelViewOffSet / (SpinTime * SpinPanDelay);
        SpinPerTick = 180.0f / SpinTime;
    }

    // Update is called once per frame
    void Update()
    {


        if (Spinning == true)
        {

            CurrentSpinTime += Time.deltaTime;

            //Pan Camera
            if (CurrentSpinTime < SpinTime * SpinPanDelay)
            {

                Vector3 PanPos = mainCamera.transform.position;
                if (LevelSelect)
                {
                    PanPos.y -= PanPerTick * Time.deltaTime;
                }
                else
                {

                    PanPos.y += PanPerTick * Time.deltaTime;
                }

                mainCamera.transform.position = PanPos;
            }

            //Rotate the spinner
            transform.Rotate(new Vector3(0, 0, SpinPerTick * Time.deltaTime));
            playButton.transform.Rotate(new Vector3(0, 0, -SpinPerTick * Time.deltaTime));
            volumeButton.transform.Rotate(new Vector3(0, 0, -SpinPerTick * Time.deltaTime));
            settingButton.transform.Rotate(new Vector3(0, 0, -SpinPerTick * Time.deltaTime));

            if (CurrentSpinTime > SpinTime / 2 && !IconFlip)
            {
                playButton.GetComponent<PlayButton>().SwapIcon();
                IconFlip = true;
            }

            if (CurrentSpinTime > SpinTime)
            {
                Spinning = false;
                CurrentSpinTime = 0.0f;
                LevelSelect = !LevelSelect;
                IconFlip = false; 
            }
        }
    }

    public void Spin()
    {

        Spinning = true;
    }
}
