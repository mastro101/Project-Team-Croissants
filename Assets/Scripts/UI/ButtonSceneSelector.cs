﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneSelector : MonoBehaviour
{
    public int numeroScena;

    public void SelectScene()
    {
        FindObjectOfType<GameManager>().SelectedLevel = numeroScena;
        SceneManager.LoadScene("BaseScene");
    }
}
