using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using StateMachine.Menu;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SelectLevel))]
public class SelectLevelMenu : MonoBehaviour
{
    SelectLevel selectLevel;
    [SerializeField]
    Image currentLevelImage, prevLevelImage, nextLevelImage;
    [SerializeField]
    TextMeshProUGUI NameText;
    GameManager gameManager;
    SetController setController;

    bool choosed;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        selectLevel = GetComponent<SelectLevel>();
        setController = FindObjectOfType<SetController>();
    }

    private void Start()
    {
        choosed = false;
        selectLevel.changeLevel = changeIcon;
        changeIcon();
    }

    void changeIcon()
    {
        LevelData currentLevel = selectLevel.currentLevel;
        currentLevelImage.sprite = currentLevel.Preview;
        prevLevelImage.sprite = selectLevel.prevLevel.Preview;
        nextLevelImage.sprite = selectLevel.nextLevel.Preview;
        NameText.text = currentLevel.Name;
    }

    bool b = false;
    private void Update()
    {
        if (setController.AssignedController.Count >= 1 && !choosed)
        {
            if (Input.GetButtonDown("J" + setController.AssignedController[0].ToString() + "A") || (Input.GetKeyDown(KeyCode.Space)) || (Input.GetKeyDown(KeyCode.Return)))
            {
                choose();
            }

            if (Input.GetAxis("J" + setController.AssignedController[0].ToString() + "H") > 0.7f && b == false)
            {
                selectLevel.NextLevel();
                FindObjectOfType<AudioManager>().Play("MenuScrolling");
                b = true;
            }
            else if (Input.GetAxis("J" + setController.AssignedController[0].ToString() + "H") < -0.7f && b == false)
            {
                selectLevel.PrevLevel();
                FindObjectOfType<AudioManager>().Play("MenuScrolling");
                b = true;
            }
            else if (Input.GetAxis("J" + setController.AssignedController[0].ToString() + "H") < 0.7f && Input.GetAxis("J" + setController.AssignedController[0].ToString() + "H") > -0.7f)
                b = false;
        }
        else if (!choosed && setController.AssignedController.Count < 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                selectLevel.NextLevel();
                FindObjectOfType<AudioManager>().Play("MenuScrolling");
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                selectLevel.PrevLevel();
                FindObjectOfType<AudioManager>().Play("MenuScrolling");
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                choose();
            }

        }
    }

    void choose()
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
        gameManager.SelectedLevel = selectLevel.currentLevel.ID;
        choosed = true;

        FindObjectOfType<MenuSM>().goNext();
        SceneManager.LoadScene("Ambientazione2");
    }
}