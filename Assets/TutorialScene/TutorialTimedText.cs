using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimedText : MonoBehaviour
{
    public GameObject tut1, tut2, tut3, tut4, tut5;
    public float tutorialTimer;
    [SerializeField]
    Rocket rocket;
    [SerializeField]
    GameObject rocketGraphics;

    public int secondMessage = 15, thirdMessage =30, fourthMessage = 45, fifthMessage = 60, endMessage = 75;

    // Update is called once per frame
    void Update()
    {
        tutorialTimer += Time.deltaTime;

        if (tutorialTimer >= endMessage)
        {
            tut5.SetActive(false);
        }

        else if (tutorialTimer >= fifthMessage)
        {
            rocket.MovementSpeed = 2;
            tut4.SetActive(false);
            tut5.SetActive(true);
        }

        else if (tutorialTimer >= fourthMessage)
        {
            Debug.Log("fourthMessage");
            rocketGraphics.SetActive(true);
            
            tut3.SetActive(false);
            tut4.SetActive(true);
        }

        else if (tutorialTimer >= thirdMessage)
        {
            Debug.Log("thirddMessage");
            
            

            tut2.SetActive(false);
            tut3.SetActive(true);
        }

        else if (tutorialTimer >= secondMessage)
        {
            
            Debug.Log("secondMessage");
            tut1.SetActive(false);
            tut2.SetActive(true);
        }
        else if (tutorialTimer >= 0)
        {
            rocketGraphics.SetActive(false);
            rocket.MovementSpeed = 0;

        }
        



    }
}
