﻿using UnityEngine;
using System.Collections;

public class BuffEffects : MonoBehaviour
{
    public GameObject SlowEffect, StunEffect, InvertAbility, AcceleratorEffect;

    public static BuffEffects instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
