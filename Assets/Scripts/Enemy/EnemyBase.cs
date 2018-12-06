using UnityEngine;
using System.Collections;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public abstract float MovementSpeed { get; set; }

    public abstract IPlayer PlayerToFollow { get; set; }

    public abstract void Movement();

    /// <summary>
    /// Evento attivato quando colpisce un Player
    /// </summary>
    public event EnemyEvent.EnemyDelegate HitPlayer;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision with " + collider.gameObject.name);
        if (collider.gameObject.GetComponent<IPlayer>() != null)
        {
            invockHit(collider.gameObject.GetComponent<IPlayer>());
        }
    }

    protected void invockHit(IPlayer player)
    {
        if (HitPlayer != null)
            HitPlayer(player);
    }
}
