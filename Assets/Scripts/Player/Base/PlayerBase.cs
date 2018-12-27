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
                playerPoint.text = "Player " + ID + " has " + points + " Points";
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

    public virtual void AddPoint(int _point)
    {
        Points += _point;
    }
}
