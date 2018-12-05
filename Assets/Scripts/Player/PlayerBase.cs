using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PlayerBase : MonoBehaviour, IPlayer
{
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
                playerPoint.text = "Player " + ID + " have " + Points + " Points";
        }
    }

    [SerializeField]
    TextMeshProUGUI playerPoint;

    public abstract float MovementSpeed { get; set; }

    public virtual void PlayerInput()
    {

    }

    public virtual void AddPoint(int _point)
    {
        Points += _point;
    }
}
