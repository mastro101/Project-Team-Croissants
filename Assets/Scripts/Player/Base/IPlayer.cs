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
    string Name { get; }
    int Points { get; set; }
    float MovementSpeed { get; set; }
    float DashDistance { get; set; }
    float DashDuration { get; }
    float DashCooldown { get; }
    float AbilityCooldown { get; }
    float OriginalSpeed { get; }
    GameObject Aim { get; }
    Sprite SelectCharacterSprite { get; }
    Sprite AbilitySprite { get; }
    Sprite IconCharacterSprite { get; }
    bool IsGameOver { get; set; }
    Color Color { get; set; }
    ParticleSystem DashVFX { get; set; }
    GameObject VictoryAnimation { get; }
    Sprite SelectedCharacterSprite { get; }
    string AbilityDescription { get; }
    //float JumpForce { get; }

    // Abilità unica del personaggio
    void Ability();

    /// <summary>
    /// Aggiunge <paramref name="_point"/> Punti al Player
    /// </summary>
    /// <param name="_point"></param>
    void AddPoint(int _point);
}

