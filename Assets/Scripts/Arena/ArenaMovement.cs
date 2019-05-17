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

    [SerializeField] public float movementDuration = 1;

    [SerializeField] public float WaitTime = 0;

    public AnimationCurve Curve = AnimationCurve.Linear(0,0,1,1);

    Tween tween;
    Vector3 oldPosition;

    //MEGA PROVVISORIO
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            MoveArena();
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
            gameplaysm.startBattle += MoveArena;
            gameplaysm.endBattle += spawn;
        }
    }

    public void SetValue(Vector3 _newPosition, float _movementDuration, float _waitTime, AnimationCurve _curve)
    {
        newPosition = _newPosition;
        movementDuration = _movementDuration;
        WaitTime = _waitTime;
        Curve = _curve;
    }

    void MoveArena()
    {
        oldPosition = transform.position;
        tween = wallToMove.DOMove(newPosition, movementDuration).SetDelay<Tween>(WaitTime).SetEase(Curve).SetAutoKill<Tween>(false).SetRelative();            
    }

    public void spawn()
    {
        tween.Pause();
        tween.Rewind(true);        
        transform.position = oldPosition;
    }
}
