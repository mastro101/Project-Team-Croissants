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
    public Vector3 newPosition;

    [SerializeField] public float movementDuration;

    [SerializeField] public float WaitTime;


    Tween tween;
    Vector3 oldPosition;


    private void Awake()
    {
        gameplaysm = FindObjectOfType<GameplaySM>();
        wallToMove = transform;        
    }

    private void Start()
    {
        if (gameplaysm != null)
        {
            gameplaysm.startBattle += MoveArena;
            gameplaysm.endBattle += spawn;
        }
    }

    public void SetValue(Vector3 _newPosition, float _movementDuration, float _waitTime)
    {
        newPosition = _newPosition;
        movementDuration = _movementDuration;
        WaitTime = _waitTime;
    }

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
