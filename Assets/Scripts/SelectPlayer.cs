using System.Collections.Generic;
using UnityEngine;
using StateMachine.Menu;

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
            else if (set.AssignedController.Count > 0)
            {
                if (Input.GetButtonDown("J" + set.AssignedController[0].ToString() + "A"))
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
            else if (set.AssignedController.Count > 1)
            {
                if (Input.GetButtonDown("J" + set.AssignedController[1].ToString() + "A"))
                    checkPlayer2();
            }
        }

        if (set.AssignedController.Count > 2 && !threePressed)
        {
            if (Input.GetButtonDown("J" + set.AssignedController[2].ToString() + "A"))
                checkPlayer3();
        }

        if (set.AssignedController.Count > 3 && !fourPressed)
        {
            if (Input.GetButtonDown("J" + set.AssignedController[3].ToString() + "A"))
                checkPlayer4();
        }
         
        if (FindObjectOfType<GameManager>().PlayersGO[0] != null)
        {
            check();
        }
    }

    void checkPlayer1()
    {
        set.NPlayer++;
        onePressed = true;
        pressA1.SetActive(false);
        selectCMenu1.GetComponent<SelectCharacter>().Init();
        selectCMenu1.SetActive(true);
        selectCMenu1.GetComponent<SelectCharacter>().angolini[0].gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
        //Player1Text.text = "Ok";
        //check();
    }

    void checkPlayer2()
    {
        set.NPlayer++;
        twoPressed = true;
        pressA2.SetActive(false);
        selectCMenu2.GetComponent<SelectCharacter>().Init();
        selectCMenu2.SetActive(true);
        selectCMenu2.GetComponent<SelectCharacter>().angolini[0].gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
        //Player2Text.text = "Ok";
        //check();
    }

    void checkPlayer3()
    {
        set.NPlayer++;
        threePressed = true;
        pressA3.SetActive(false);
        selectCMenu3.GetComponent<SelectCharacter>().Init();
        selectCMenu3.SetActive(true);
        selectCMenu3.GetComponent<SelectCharacter>().angolini[0].gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
    }

    void checkPlayer4()
    {
        set.NPlayer++;
        fourPressed = true;
        pressA4.SetActive(false);
        selectCMenu4.GetComponent<SelectCharacter>().Init();
        selectCMenu4.SetActive(true);
        selectCMenu4.GetComponent<SelectCharacter>().angolini[0].gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
    }


    void check()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Return))
        {
            if (FindObjectOfType<GameManager>().PlayersGO.Length == 1)
            {
                FindObjectOfType<GameManager>().PlayersGO[1] = Characters[0];
            }
            FindObjectOfType<MenuSM>().goNext();
        }
    }
}
