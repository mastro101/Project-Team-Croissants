using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    GameObject gameObject { get; }
    Transform transform { get; }
    int ID { get; }
    int Points { get; set; }
    float MovementSpeed { get; set; }
    void PlayerInput();

    void AddPoint(int _point);
}

