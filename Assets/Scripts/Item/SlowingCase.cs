﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SlowingCase : ItemBase
{
    [SerializeField]
    GameObject slowingObject;
    [SerializeField]
    float ExpandValue;

    Transform slowingSpawn;


    Vector3 directionFall;
    Vector3 oldPosition;
    Quaternion oldRotation;

    protected override void Awake()
    {
        base.Awake();
        oldPosition = GetComponent<Transform>().position;
        oldRotation = GetComponent<Transform>().rotation;
        slowingSpawn = gameObject.GetComponentInChildren<Transform>();
    }



    public override void OnSpawn()
    {
        base.OnSpawn();
        collider.enabled = true;
        transform.rotation = oldRotation;
        transform.position = oldPosition;
    }

    public override void OnTake(IPlayer player)
    {
        base.OnTake(player);
        collider.enabled = false;
        directionFall = player.gameObject.GetComponent<PlayerController>().Direction;
        transform.rotation = Quaternion.LookRotation(directionFall);
        transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetRelative();
    }

    GameObject slowing;
    public override void Effect(IPlayer _player)
    {
        slowing = Instantiate(slowingObject, slowingSpawn.position, Quaternion.LookRotation(directionFall));
        slowing.transform.DOScaleZ(ExpandValue, 1);
    }
}