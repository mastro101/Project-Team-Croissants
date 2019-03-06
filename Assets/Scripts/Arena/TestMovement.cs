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


    [SerializeField] Vector3 newPosition;

    [SerializeField] Transform oldPosition;

    [SerializeField] float movementDuration;

    [SerializeField] float WaitTime;

    public Vector3[] paths;
    public LoopType looptype;
    public int looptimes = -1;

    Tween tween;


    private void Awake()
    {
        wallToMove = transform;
        oldPosition = transform;
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            path();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            trovalaposition();
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

    void trovalaposition()
    {
        Debug.Log("pd " + oldPosition);
    }

    public void path()
    {
        tween = wallToMove.DOPath(paths, movementDuration).SetLoops<Tweener>(looptimes, looptype).SetRelative();

    }
}

