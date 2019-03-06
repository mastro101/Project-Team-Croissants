using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine.Gameplay;
using System;

public class ArenaMovement : MonoBehaviour
{
    Transform wallToMove;

    GameplaySM gameplaysm;


    [SerializeField]
    Vector3 newPosition;

    [SerializeField] float movementDuration;

    [SerializeField] float WaitTime;


    Tween tween;
    Vector3 oldPosition;


    private void Awake()
    {
        gameplaysm = FindObjectOfType<GameplaySM>();
        wallToMove = transform;        
    }

    private void Start()
    {
        gameplaysm.startBattle += MoveArena;
        gameplaysm.endBattle += spawn;        
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        MoveArena();
    //    }
    //
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        spawn();
    //    }
    //}


    void MoveArena()
    {
        oldPosition = transform.position;
        tween = wallToMove.DOMove(newPosition, movementDuration).SetDelay<Tween>(WaitTime).SetEase(Ease.Linear).SetAutoKill<Tween>(false).SetRelative();            
    }


    public void spawn()
    {
        tween.Pause();
        tween.Rewind(true);        
        transform.position = oldPosition;
    }
}
