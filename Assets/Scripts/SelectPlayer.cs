using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectPlayer : MonoBehaviour
{
    public List<GameObject> Characters;

    [SerializeField]
    string sceneName;
    bool onePressed, twoPressed, threePressed, fourPressed;
    SetController set;

    [SerializeField]
    GameObject pressA1, pressA2, pressA3, pressA4;
    [SerializeField]
    GameObject selectCMenu1, selectCMenu2, selectCMenu3, selectCMenu4;

    private void Awake()
    {
        set = FindObjectOfType<SetController>();
        set.NPlayer = 0;
    }

    private void Start()
    {
        FindObjectOfType<GameManager>().PlayersGO = new GameObject[4];
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

        if (set.assignedController.Count > 2 && !threePressed)
        {
            if (Input.GetButtonDown("J" + set.assignedController[2].ToString() + "A"))
                checkPlayer3();
        }

        if (set.assignedController.Count > 3 && !fourPressed)
        {
            if (Input.GetButtonDown("J" + set.assignedController[3].ToString() + "A"))
                checkPlayer4();
        }
         
        if (FindObjectOfType<GameManager>().PlayersGO[1] != null)
        {
            check();
        }
    }

    void checkPlayer1()
    {
        set.NPlayer++;
        onePressed = true;
        pressA1.SetActive(false);
        selectCMenu1.SetActive(true);
        //Player1Text.text = "Ok";
        //check();
    }

    void checkPlayer2()
    {
        set.NPlayer++;
        twoPressed = true;
        pressA2.SetActive(false);
        selectCMenu2.SetActive(true);
        //Player2Text.text = "Ok";
        //check();
    }

    void checkPlayer3()
    {
        set.NPlayer++;
        threePressed = true;
        pressA3.SetActive(false);
    }

    void checkPlayer4()
    {
        set.NPlayer++;
        fourPressed = true;
        pressA4.SetActive(false);
    }


    void check()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SceneSelector");
        }
    }

    
}
