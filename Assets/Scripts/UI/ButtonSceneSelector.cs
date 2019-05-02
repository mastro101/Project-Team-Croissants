using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSelector : MonoBehaviour
{
    public string NomeScena;

    public void SelectScene()
    {
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        SceneManager.LoadScene("NuovaBaseScene");
    }
}
