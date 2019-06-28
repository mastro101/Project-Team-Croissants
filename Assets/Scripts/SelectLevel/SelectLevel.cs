using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public object[] LevelsOnDisck;
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
            //changeLevel?.Invoke();
        }
    }
    LevelData p1;
    public LevelData nextLevel
    {
        get
        {
            return p1;
        }
        set
        {
            p1 = value;
            //changeLevel?.Invoke();
        }
    }
    LevelData p2;
    public LevelData prevLevel
    {
        get
        {
            return p2;
        }
        set
        {
            p2 = value;
            //changeLevel?.Invoke();
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
    int q;
    int nextLevelInList
    {
        get { return q; }
        set
        {
            q = value;
            if (q >= levels.Count)
                q = 0;
            else if (q < 0)
                q = levels.Count - 1;
        }
    }
    int m;
    int prevLevelInList
    {
        get { return m; }
        set
        {
            m = value;
            if (m >= levels.Count)
                m = 0;
            else if (m < 0)
                m = levels.Count - 1;
        }
    }

    private void Awake()
    {
        levels = new List<LevelData>();
        LevelsOnDisck = Resources.LoadAll("LevelData", typeof(LevelData));
        foreach (LevelData _level in LevelsOnDisck)
        {
            levels.Add(_level);
            Debug.Log("Aggiunto " + _level);
        }
        levelInList = 0;
        nextLevelInList = 1;
        prevLevelInList = levels.Count - 1;
        currentLevel = levels[0];
        prevLevel = levels[levels.Count - 1];
        nextLevel = levels[1];
        changeLevel?.Invoke();
    }

    public void NextLevel()
    {
        levelInList++;
        nextLevelInList++;
        prevLevelInList++;
        nextLevel = levels[nextLevelInList];
        currentLevel = levels[levelInList];
        prevLevel = levels[prevLevelInList];
        changeLevel?.Invoke();
    }

    public void PrevLevel()
    {
        levelInList--;
        nextLevelInList--;
        prevLevelInList--;
        nextLevel = levels[nextLevelInList];
        currentLevel = levels[levelInList];
        prevLevel = levels[prevLevelInList];
        changeLevel?.Invoke();
    }
}
