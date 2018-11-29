using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    GameObject gameObject { get; }   

    float MovementSpeed { get; set; }
    void PlayerInput();

}

