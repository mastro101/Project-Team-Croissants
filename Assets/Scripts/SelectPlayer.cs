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
    GameObject pressA1;
    [SerializeField]
    GameObject ready1;
    [SerializeField]
    GameObject pressA2;
    [SerializeField]
    GameObject ready2;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            onePressed = true;
            pressA1.SetActive(false);
            ready1.SetActive(true);
            //Player1Text.text = "Ok";
            check();
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
            Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.RightShift))
        {
            twoPressed = true;
            pressA2.SetActive(false);
            ready2.SetActive(true);
            //Player2Text.text = "Ok";
            check();
        }
    }

    void check()
    {
        if (onePressed && twoPressed)
        {
            SceneManager.LoadScene(Random.Range(1, 7));
        }
    }
}
