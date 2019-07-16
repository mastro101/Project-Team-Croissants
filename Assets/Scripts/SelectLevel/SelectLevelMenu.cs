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

    public GameObject loadTestImageScreen;
    AsyncOperation async;
    public Image loadingBar;
    public TextMeshProUGUI loadText;
    [SerializeField]
    TextMeshProUGUI loadingText;
    [SerializeField]
    Sprite[] loadingBackgrounds;
    string[,] loadingString;

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
        setText();
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

        StartCoroutine(caricalivello());


        choosed = true;


    }

    IEnumerator caricalivello()
    {
        int randomCharacterInt = Random.Range(0, loadingBackgrounds.Length);
        int randomTextInt = Random.Range(0, 2);

        loadTestImageScreen.GetComponent<Image>().sprite = loadingBackgrounds[randomCharacterInt];
        loadingText.text = loadingString[randomCharacterInt, randomTextInt];
        loadTestImageScreen.SetActive(true);

        gameManager.SelectedLevel = selectLevel.currentLevel.ID;
        FindObjectOfType<MenuSM>().goNext();
        async = SceneManager.LoadSceneAsync("Ambientazione2");



        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadingBar.fillAmount = progress;
            loadText.text = "Loading...         " + (progress * 99f).ToString("F0") + "%";
            Debug.Log(progress);
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }

    void setText()
    {
        loadingString = new string[,]
        {
            { "Trinity has a real knack for programming. And also explosions!" , "I heard Trinity whispering something about the PartyX having me..." } ,
            { "Veeky’s favourite motto is: “Punk ain’t dead… you are!”" , "Watch your step, if you don’t want to blow up." } ,
            { "Watch out, SameID has friends on the other side!" , "When I got close to SameID, my mind got hazy..." } ,
            { "Did you hear that hellish sound? I think it was Wendigo’s laughter!" , "Ouch, something cut me! ...oh, it was Wendigo’s edge." }
        };
    }
}