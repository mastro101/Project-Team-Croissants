using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public Image[] angolini;

    [HideInInspector]
    public List<GameObject> characters;
    public Action changeCharacter;
    GameObject p;
    public GameObject currentPlayer
    {
        get
        {
            return p;
        }
        set
        {
            p = value;
            if (changeCharacter != null)
            {
                changeCharacter();
            }
        }
    }

    int n;
    int playerInList
    {
        get { return n; }
        set
        {
            n = value;
            if (n >= characters.Count)
                n = 0;
            else if (n < 0)
                n = characters.Count - 1;
        }
    }

    public void Init()
    {
        playerInList = 0;
        characters = FindObjectOfType<SelectPlayer>().Characters;
        currentPlayer = characters[0];
        foreach (Image _angolini in angolini)
        {
            _angolini.gameObject.SetActive(true);
            _angolini.enabled = false;
        }
        angolini[0].gameObject.SetActive(false);
        angolini[0].enabled = true;
    }

    public void NextCharacter()
    {
        angolini[playerInList].enabled = false;
        playerInList++;
        currentPlayer = characters[playerInList];
        angolini[playerInList].enabled = true;
    }

    public void PrevCharacter()
    {
        angolini[playerInList].enabled = false;
        playerInList--;
        currentPlayer = characters[playerInList];
        angolini[playerInList].enabled = true;
    }
}
