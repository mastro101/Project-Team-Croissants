﻿using UnityEngine;
using System.Collections;

public class PlayerPunk : PlayerBase
{
    [SerializeField]
    GameObject trapPrefab;

    public override int ID
    {
        get
        {
            return 2;
        }
    }

    public override string Name
    {
        get
        {
            return "Punk-ina";
        }
    }

    public override void Ability()
    {
        Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0, 0));

        SM.SetBool("Ability", false);
    }
}
