using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    [HideInInspector]
    public List<LevelData> levels;
    public Action changeLevel;
    LevelData p;
    public LevelData currentLevel
    {
        get
        {
            return p;
        }
        set
        {
            p = value;
            changeLevel?.Invoke();
        }
    }

    int n;
    int levelInList
    {
        get { return n; }
        set
        {
            n = value;
            if (n >= levels.Count)
                n = 0;
            else if (n < 0)
                n = levels.Count - 1;
        }
    }

    private void Awake()
    {
        levelInList = 0;
        levels = FindObjectOfType<LevelConteiner>().Levels;
        currentLevel = levels[0];
    }

    public void NextLevel()
    {
        levelInList++;
        currentLevel = levels[levelInList];
    }

    public void PrevLevel()
    {
        levelInList--;
        currentLevel = levels[levelInList];
    }
}
