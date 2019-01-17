using UnityEngine;
using System.Collections;
using UnityEditor;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    [SerializeField]
    float movementSpeed;
    public virtual float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }

    [Range(0f, 1f)]
    [SerializeField]
    float rotationSpeed;
    public virtual float RotationSpeed { get { return rotationSpeed; } set { rotationSpeed = value; } }

    public virtual IPlayer PlayerToFollow { get; set; }

    public virtual Animator SM { get { return GetComponent<Animator>(); } }

    public virtual void Movement() { }

    public virtual void Ability() { }

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
