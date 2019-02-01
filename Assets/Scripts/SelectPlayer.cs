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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            onePressed = true;
            Player1Text.text = "Ok";
            check();
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button0))
        {
            twoPressed = true;
            Player2Text.text = "Ok";
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
