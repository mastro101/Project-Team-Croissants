using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine.Gameplay;
using System;

public class LoopsMovement : MonoBehaviour
{
    Transform wallToMove;

    GameplaySM gameplaysm;

    public Vector3[] paths;

    [SerializeField] float movementDuration;

    [SerializeField] float WaitTime;

    public LoopType looptype;
    public int looptimes = -1;

    Tween tween;


    private void Awake()
    {
        wallToMove = transform;
       
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PathMovements();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawn();
        }


    }



    public void spawn()
    {
        tween.Complete();
        tween.Rewind(true);
        tween.Kill();

    }


    public void PathMovements()
    {
        tween = wallToMove.DOPath(paths, movementDuration).SetLoops<Tweener>(looptimes, looptype).SetDelay(WaitTime).SetRelative();

    }
}
