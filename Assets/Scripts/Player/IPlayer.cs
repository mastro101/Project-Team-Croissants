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

    /// <summary>
    /// Contiene i comandi del Player
    /// </summary>
    void PlayerInput();

    /// <summary>
    /// Aggiunge <paramref name="_point"/> Punti al Player
    /// </summary>
    /// <param name="_point"></param>
    void AddPoint(int _point);
}

