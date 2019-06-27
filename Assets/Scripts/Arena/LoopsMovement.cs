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

    public Vector3[] Paths = new Vector3[1];

    [SerializeField] public float MovementDuration = 1;

    [SerializeField] public float WaitTime = 0;

    [SerializeField] public AnimationCurve Curve = AnimationCurve.Linear(0, 0, 1, 1);

    public LoopType LoopType;
    public int Looptimes = -1;

    Tween tween;

    //MEGA PROVVISORIO
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.P))
            PathMovements();
    }

    private void Awake()
    {
        gameplaysm = FindObjectOfType<GameplaySM>();
        wallToMove = transform;
    }

    private void Start()
    {
        if (gameplaysm != null)
        {
            gameplaysm.startBattle += PathMovements;
            gameplaysm.endBattle += spawn;
        }
    }

    public void SetValue(Vector3[] _paths, float _movementDuration, float _waitTime, AnimationCurve _curve, LoopType _loopType, int _loopTimes)
    {
        int n = 0;
        foreach (Vector3 p in _paths)
        {
            Paths[n] = p;
            n++;
        }
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
        //AH pezzo di merda
        if (Paths.Length > 0)
            tween = wallToMove.DOPath(Paths, MovementDuration).SetLoops<Tweener>(Looptimes, LoopType).SetDelay(WaitTime).SetRelative().SetEase(Curve);
    }
}
