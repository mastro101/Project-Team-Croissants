using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
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

    private void Awake()
    {
        playerInList = 0;
        characters = FindObjectOfType<SelectPlayer>().Characters;
        currentPlayer = characters[0];
    }

    public void NextCharacter()
    {
        playerInList++;
        currentPlayer = characters[playerInList];
    }

    public void PrevCharacter()
    {
        playerInList--;
        currentPlayer = characters[playerInList];
    }
}
