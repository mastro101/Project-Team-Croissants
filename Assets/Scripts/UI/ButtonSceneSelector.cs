using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachine.Menu;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonSceneSelector : MonoBehaviour
{
    public string NomeScena;
    public GameObject loadTestImageScreen;
    public Slider loadingBar;
    public TextMeshProUGUI loadText;

    Selectable sel;
    AsyncOperation async;

    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuScrolling");
    }

    public void SelectScene()
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        FindObjectOfType<MenuSM>().goNext();
        SceneManager.LoadScene("Ambientazione2");
    }

    public void LoadScreen()
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
        StartCoroutine(caricalivello());

    }
    
    IEnumerator caricalivello()
    {
        loadTestImageScreen.SetActive(true);
        
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        FindObjectOfType<MenuSM>().goNext();
        async = SceneManager.LoadSceneAsync("Ambientazione2");

       

        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadingBar.value = progress;
            loadText.text = "Loading...         " + (progress * 100f).ToString("F0") + "%";
            Debug.Log(progress);
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }



   
}
