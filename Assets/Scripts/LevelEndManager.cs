using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndManager : MonoBehaviour {

    public GUIText StarCountText;
    public GUIText TimeTakenText;
    public GUIText FluffText;

    // Use this for initialization
    void Start () {

        StarCountText.text = PlayerPrefs.GetInt("Stars Linked").ToString();
        TimeTakenText.text = PlayerPrefs.GetFloat("Time elapsed").ToString();

        int ExpectedCount = 0;
        string Fluff = "";

        switch (PlayerPrefs.GetInt("LastLevelComplete", 0))
        {

            case 1:
                ExpectedCount = 3;
                Fluff = "The fox awoke with the first rays of light. It yawned, shook off the dust and left its den.";
                break;

            case 2:
                ExpectedCount = 3;
                Fluff = "Slowly, the dark bear woke from its long hibernation. Its stomach grumbling. Somewhere, it sensed prey.";
                break;

            case 3:
                ExpectedCount = 3;
                Fluff = "Across the hills, the bear saw the bright glow of the fox. It took to the chase and the fox tried to flee.";
                break;

            case 4:
                ExpectedCount = 3;
                Fluff = "The fox ran and ran. For a moment, it seemed to have lost the bear. Thinking ahead, it planted a seed.";
                break;

            case 5:
                ExpectedCount = 3;
                Fluff = "The bear caught up with the fox, and a thick fog started to settle. The both of them ran into it, head first.";
                break;

            case 6:
                ExpectedCount = 3;
                Fluff = "Running aimless through the fog, the fox met a firefly. Quickly, the fox pleaded the firefly for a favour and continued running as the dark shape of the bear began to appear.";
                break;

            case 7:
                ExpectedCount = 3;
                Fluff = "As the fog cleared, the fox saw that the seed it had planted had grown into a forest of trillions of stars. It ran and hid between them. ";
                break;

            case 8:
                ExpectedCount = 3;
                Fluff = "While the bear was wandering aimlessly through the forest of stars, the fox met a frog. The frog promised to keep the fox safe, but with load croaking it gave away the fox’s hiding spot to the bear.";
                break;

            case 9:
                ExpectedCount = 3;
                Fluff = "Determined to end the chase, the bear grew to an enormous size and darkened the sky. As night fell, the fox’s light weakened.";
                break;

            case 10:
                ExpectedCount = 3;
                Fluff = "In an instant, the forest of stars returned to its seed. The fox flashed with light and returned to its den. As the bear’s eyesight cleared, the fox was gone. With high hope for the next chase, the bear returned to sleep.";
                break;

            default:
                break;
        }

        if (PlayerPrefs.GetInt("Stars Linked") >= ExpectedCount / 2)
        {

            //Display the text
            FluffText.text = Fluff;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
