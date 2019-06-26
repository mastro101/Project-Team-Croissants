using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimedText : MonoBehaviour
{
    public GameObject tut1, tut2, tut3, tut4;
    public float tutorialTimer;

    public int secondMessage = 15, thirdMessage =30, fourthMessage = 45, endMessage = 60;

    // Update is called once per frame
    void Update()
    {
        tutorialTimer += Time.deltaTime;

        if (tutorialTimer >= endMessage)
        {
            tut4.SetActive(false);
        }

        else if (tutorialTimer >= fourthMessage)
        {
            tut3.SetActive(false);
            tut4.SetActive(true);
        }

        else if (tutorialTimer >= thirdMessage)
        {
            tut2.SetActive(false);
            tut3.SetActive(true);
        }

        else if (tutorialTimer >= secondMessage)
        {
            tut1.SetActive(false);
            tut2.SetActive(true);
        }
        



    }
}
