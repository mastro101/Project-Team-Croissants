using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    GameObject gameObject { get; }
    Transform transform { get; }
    Rigidbody rigidbody { get; }
    Animator SM { get; }
    int ID { get; }
    int Points { get; set; }
    float MovementSpeed { get; set; }
    float DashDistance { get; set; }
    float DashDuration { get; }
    float DashCooldown { get; }
    float OriginalSpeed { get; }
    //float JumpForce { get; }

    /// <summary>
    /// Aggiunge <paramref name="_point"/> Punti al Player
    /// </summary>
    /// <param name="_point"></param>
    void AddPoint(int _point);
}

