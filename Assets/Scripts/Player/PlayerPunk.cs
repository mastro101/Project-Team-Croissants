﻿using UnityEngine;
using System.Collections;

public class PlayerPunk : PlayerBase
{
    [SerializeField]
    GameObject trapPrefab;
    [HideInInspector]
    public GameObject VFXEffectTrap;

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
            return "Veeky";
        }
    }

    public override void Ability()
    {
        base.Ability();
        GameObject trap = Instantiate(trapPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        trap.GetComponent<Trap>().SetPlayer(this);
        FindObjectOfType<AudioManager>().Play("PunkAbility");

        SM.SetBool("Ability", false);
    }
}
