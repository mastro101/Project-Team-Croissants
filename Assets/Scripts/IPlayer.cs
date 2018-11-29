using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    GameObject gameObject { get; }
    Transform transform { get; }

    float MovementSpeed { get; set; }
    void PlayerInput();

}

