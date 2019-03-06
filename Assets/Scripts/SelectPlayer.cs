using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    bool onePressed, twoPressed;
    SetController set;

    [SerializeField]
    GameObject pressA1;
    [SerializeField]
    GameObject ready1;
    [SerializeField]
    GameObject pressA2;
    [SerializeField]
    GameObject ready2;

    private void Awake()
    {
        set = FindObjectOfType<SetController>();
    }

    void Update()
    {
        set.AssigneController();

        if (onePressed == false)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
            {
                checkPlayer1();
            }
            else if (set.assignedController.Count > 0)
            {
                if (Input.GetButtonDown("J" + set.assignedController[0].ToString() + "A"))
                    checkPlayer1();
            }
        }

        if (twoPressed == false)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.RightShift))
            {
                checkPlayer2();
            }
            else if (set.assignedController.Count > 1)
            {
                if (Input.GetButtonDown("J" + set.assignedController[1].ToString() + "A"))
                    checkPlayer2();
            }
        }
    }

    void checkPlayer1()
    {
        onePressed = true;
        pressA1.SetActive(false);
        ready1.SetActive(true);
        //Player1Text.text = "Ok";
        check();
    }

    void checkPlayer2()
    {
        twoPressed = true;
        pressA2.SetActive(false);
        ready2.SetActive(true);
        //Player2Text.text = "Ok";
        check();
    }

    void check()
    {
        if (onePressed && twoPressed)
        {
            SceneManager.LoadScene("SceneSelector");
        }
    }
}
