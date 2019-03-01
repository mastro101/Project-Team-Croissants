using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine.Gameplay;
using System;

public class TestMovement : MonoBehaviour
{
    Transform wallToMove;

    GameplaySM gameplaysm;


    [SerializeField]
    Vector3 newPosition;

    [SerializeField] float movementDuration;

    [SerializeField] float WaitTime;


    Tween tween;


    private void Awake()
    {
        wallToMove = transform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveArena();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawn();
        }
    }


    void MoveArena()
    {
        tween = wallToMove.DOMove(newPosition, movementDuration).SetDelay<Tween>(WaitTime).SetEase(Ease.Linear).SetAutoKill<Tween>(false).SetRelative();
    }


    public void spawn()
    {
        tween.Rewind(true);
    }
}

