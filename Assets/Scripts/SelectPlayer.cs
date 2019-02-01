using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    [SerializeField]
    TextMeshProUGUI Player1Text, Player2Text;
    bool onePressed, twoPressed;

    [SerializeField]
    GameObject pressA;
    [SerializeField]
    GameObject ready;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            onePressed = true;
            pressA.SetActive(false);
            ready.SetActive(true);
            //Player1Text.text = "Ok";
            check();
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            twoPressed = true;
            pressA.SetActive(false);
            ready.SetActive(true);
            //Player2Text.text = "Ok";
            check();
        }
    }

    void check()
    {
        if (onePressed && twoPressed)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
