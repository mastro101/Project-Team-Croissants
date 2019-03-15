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

    public Vector3[] Paths;

    [SerializeField] public float MovementDuration = 1;

    [SerializeField] public float WaitTime = 0;

    [SerializeField] public AnimationCurve Curve = AnimationCurve.Linear(0, 0, 1, 1);

    public LoopType LoopType;
    public int Looptimes = -1;

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

    public void SetValue(Vector3[] _paths, float _movementDuration, float _waitTime, AnimationCurve _curve, LoopType _loopType, int _loopTimes)
    {
        Paths = _paths;
        MovementDuration = _movementDuration;
        WaitTime = _waitTime;
        Curve = _curve;
        LoopType = _loopType;
        Looptimes = _loopTimes;
    }

    public void spawn()
    {
        tween.Complete();
        tween.Rewind(true);
        tween.Kill();

    }


    public void PathMovements()
    {
        tween = wallToMove.DOPath(Paths, MovementDuration).SetLoops<Tweener>(Looptimes, LoopType).SetDelay(WaitTime).SetRelative().SetEase(Curve);

    }
}
