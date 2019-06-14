using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(SelectCharacter))]
public class SelectCharacterMenu : MonoBehaviour
{
    [SerializeField] [Range(1, 4)]
    int playerInt;
    SelectCharacter selectCharacter;
    [SerializeField]
    Image currentCharacterImage, currentAbilityImage;
    [SerializeField]
    TextMeshProUGUI NameText;
    [SerializeField]
    ParticleSystem SelectedVFX;
    GameManager gameManager;
    SetController setController;

    bool choosed;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        selectCharacter = GetComponent<SelectCharacter>();
        setController = FindObjectOfType<SetController>();
        SelectedVFX.Stop();
    }

    private void Start()
    {
        choosed = false;
        selectCharacter.changeCharacter = changeIcon;
        changeIcon();
    }

    void changeIcon()
    {
        IPlayer currentPlayer = selectCharacter.currentPlayer.GetComponent<IPlayer>();
        currentCharacterImage.sprite = currentPlayer.SelectCharacterSprite;
        NameText.text = currentPlayer.Name;
        currentAbilityImage.sprite = currentPlayer.AbilitySprite;
    }

    bool b = false;
    private void Update()
    {
        if (setController.AssignedController.Count >= playerInt && !choosed)
        {
            if (Input.GetButtonDown("J" + setController.AssignedController[playerInt - 1].ToString() + "A") || (playerInt == 1 && Input.GetKeyDown(KeyCode.Space)) || (playerInt == 2 && Input.GetKeyDown(KeyCode.RightControl)))
            {
                choose();
            }

            if (Input.GetAxis("J" + setController.AssignedController[playerInt - 1].ToString() + "H") > 0.7f && b == false)
            {
                selectCharacter.NextCharacter();
                b = true;
            }
            else if (Input.GetAxis("J" + setController.AssignedController[playerInt - 1].ToString() + "H") < -0.7f && b == false)
            {
                selectCharacter.PrevCharacter();
                b = true;
            }
            else if (Input.GetAxis("J" + setController.AssignedController[playerInt - 1].ToString() + "H") < 0.7f && Input.GetAxis("J" + setController.AssignedController[playerInt - 1].ToString() + "H") > -0.7f)
                b = false;
        }
        else if (!choosed && (playerInt == 1 && Input.GetKeyDown(KeyCode.Space)) || (playerInt == 2 && Input.GetKeyDown(KeyCode.RightControl)))
        {
            choose();
        }
    }

    void choose()
    {
        Debug.Log(playerInt - 1);
        Debug.Log(selectCharacter.currentPlayer.GetComponent<IPlayer>().Name);
        SelectedVFX.Play();
        gameManager.PlayersGO[playerInt - 1] = selectCharacter.currentPlayer;
        choosed = true;
        currentCharacterImage.sprite = selectCharacter.currentPlayer.GetComponent<IPlayer>().SelectedCharacterSprite;
    }
}