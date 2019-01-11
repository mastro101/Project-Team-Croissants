﻿using UnityEngine;
using System.Collections;
using StateMachine.Gameplay;

public abstract class ItemBase : MonoBehaviour , IItem
{
    public Collider collider { get { return GetComponent<Collider>(); } }

    public MeshRenderer meshRenderer { get { return GetComponent<MeshRenderer>(); } }

    public abstract void Effect(IPlayer _player);

    EnemyBase[] enemies;

    protected GameplaySM gameplaySM;

    protected virtual void Awake()
    {
        enemies = FindObjectsOfType<EnemyBase>();
        gameplaySM = FindObjectOfType<GameplaySM>();
    }

    protected virtual void Start()
    {
        gameplaySM.endBattle += OnSpawn;
    }

    /// <summary>
    /// Chiamato quando finisce un round
    /// </summary>
    public virtual void OnSpawn()
    {
        
    }

    /// <summary>
    /// Chiamato quando un Player entra nell'area di trigger
    /// </summary>
    /// <param name="_player"></param>
    public virtual void OnTake(IPlayer player)
    {

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            OnTake(player);
            Effect(player);
        }
    }
}