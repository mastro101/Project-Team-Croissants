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
    public Slider loadingBar;
    public TextMeshProUGUI loadText;
    [SerializeField]
    Sprite[] loadingBackgrounds;

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

        StartCoroutine(caricalivello());


        choosed = true;


    }

    IEnumerator caricalivello()
    {
        loadTestImageScreen.GetComponent<Image>().sprite = loadingBackgrounds[Random.Range(0, loadingBackgrounds.Length)];
        loadTestImageScreen.SetActive(true);

        gameManager.SelectedLevel = selectLevel.currentLevel.ID;
        FindObjectOfType<MenuSM>().goNext();
        async = SceneManager.LoadSceneAsync("Ambientazione2");



        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadingBar.value = progress;
            loadText.text = "Loading...         " + (progress * 99f).ToString("F0") + "%";
            Debug.Log(progress);
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }

}