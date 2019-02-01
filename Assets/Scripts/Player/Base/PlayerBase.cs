using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public abstract class PlayerBase : MonoBehaviour, IPlayer
{
    public Animator SM { get { return GetComponent<Animator>(); } }

    public new Rigidbody rigidbody { get { return GetComponent<Rigidbody>(); } }

    public abstract int ID { get; }

    public abstract string Name { get; }

    protected int points;
    public virtual int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            if (playerPoint != null)
                playerPoint.text = Name + " has " + points + " Points";
        }
    }

    [SerializeField]
    TextMeshProUGUI playerPoint;

    [SerializeField]
    float movementSpeed;
    public virtual float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }

    //[SerializeField]
    //float jumpForce;
    //public virtual float JumpForce { get { return jumpForce; } }

    [SerializeField]
    float dashDistance;
    public virtual float DashDistance { get { return dashDistance; } set { dashDistance = value; } }

    [SerializeField]
    float dashDuration;
    public virtual float DashDuration { get { return dashDuration; } }

    [SerializeField]
    float dashCooldown;
    public virtual float DashCooldown { get { return dashCooldown; } }

    [SerializeField]
    float abilityCooldown;
    public virtual float AbilityCooldown { get { return abilityCooldown; } }

    public abstract void Ability();

    public virtual void AddPoint(int _point)
    {
        Points += _point;
    }

    float originalSpeed;
    public float OriginalSpeed { get { return originalSpeed; } }

    protected virtual void Start()
    {
        originalSpeed = MovementSpeed;
    }

    public float GetOriginalSpeed()
    {
        return OriginalSpeed;
    }
}
