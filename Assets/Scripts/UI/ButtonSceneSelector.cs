using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSelector : MonoBehaviour
{
    public int numeroScena;


    public void SelectScene()
    {
        SceneManager.LoadScene(numeroScena);
    }

}
