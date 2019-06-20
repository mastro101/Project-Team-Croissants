using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachine.Menu;
using System.Collections;

public class ButtonSceneSelector : MonoBehaviour
{
    public string NomeScena;
    public GameObject loadTest;

    AsyncOperation async;

    public void SelectScene()
    {
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        FindObjectOfType<MenuSM>().goNext();
        SceneManager.LoadScene("Ambientazione2");
    }

    public void LoadScreen()
    {
        StartCoroutine(caricalivello());

    }
    
    IEnumerator caricalivello()
    {
        loadTest.SetActive(true);
        
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        FindObjectOfType<MenuSM>().goNext();
        async = SceneManager.LoadSceneAsync("Ambientazione2");

        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            Debug.Log(async.progress);
            if (async.progress == 0.9f)
            {   
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }
   
}
