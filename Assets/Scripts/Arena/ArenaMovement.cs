using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine.Gameplay;
using System;

public class ArenaMovement : MonoBehaviour
{
    public Transform wallToMove;

   GameplaySM gameplaysm;

    Vector3 oldPosition;

    [SerializeField]
    Vector3 newPosition;

    public float movementDuration;

    public float WaitTime;


    Tween tween;


    private void Start()
    {
     //  gameplaysm.endBattle += spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveArena();
        }
    }


    void MoveArena()
    {
            tween = wallToMove.DOMove(newPosition, movementDuration).SetDelay<Tween>(WaitTime).SetEase(Ease.Linear);
            
    }


    public void spawn()
    {
        tween.Restart();
    }
}
