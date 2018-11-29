using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public abstract float MovementSpeed { get; set; }

    public abstract IPlayer PlayerToFollow { get; }
}
