using System.Collections.Generic;
using UnityEngine;

public class LevelConteiner : MonoBehaviour
{
    public object[] Levels;

    private void Awake()
    {
        Levels = Resources.LoadAll("LevelData", typeof(LevelData));
    }
}
