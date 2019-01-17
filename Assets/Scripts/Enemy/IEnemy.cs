using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy {

    GameObject gameObject { get; }
    Transform transform { get; }
	float MovementSpeed { get; set; }
    float RotationSpeed { get; set; }
    IPlayer PlayerToFollow { get; set; }
    Animator SM { get; }

    /// <summary>
    /// Evento attivato quando colpisce un Player
    /// </summary>
    event EnemyEvent.EnemyDelegate HitPlayer;

    void Movement();
    void Ability();
}

public class EnemyEvent
{
    public delegate void EnemyDelegate(IPlayer player);
}
