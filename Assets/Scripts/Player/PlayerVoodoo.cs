﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerVoodoo : PlayerBase
{
    [SerializeField]
    float effectTime, timerAbility;

    [SerializeField]
    public GameObject InverterBarrier;

    bool isEffect;
    BuffEffects effect;

    public override int ID
    {
        get
        {
            return 1;
        }
    }

    public override string Name
    {
        get
        {
            return "BarOne";
        }
    }
    GameObject _effect;
    public override void Ability()
    {
        base.Ability();
        //Graphic.GetComponent<MeshRenderer>().material.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo);
        effect = FindObjectOfType<BuffEffects>();
        FindObjectOfType<AudioManager>().Play("VooDooAbility");
        _effect = Instantiate(effect.InvertAbility, transform.position + new Vector3(0, 3.5f, 0), transform.rotation, transform);
        Instantiate(InverterBarrier, transform.position + (Vector3.up * 1), Quaternion.Euler(Vector3.zero), transform).GetComponent<InvertMovement>().SetTimer(timerAbility, effectTime);
        /*isEffect = true;
        StartCoroutine(StopEffect());
        Debug.Log(isEffect);*/
        SM.SetBool("Ability", false);
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(effectTime);
        isEffect = false;
        Debug.Log(isEffect);
    }

    override protected void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (isEffect)
        {
            if (player != null)
            {
                isEffect = false;
                player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Invert, 0, 6);
            }
        }
    }
}
