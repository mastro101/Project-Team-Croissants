using UnityEngine;
using System.Collections;

public class RocketAccelerator : PowerUpBase
{
    [SerializeField]
    float addedSpeed;

    public override void Effect(IPlayer _player)
    {
        Rocket rocket;
        if (_player.ID == 2)
        {
            rocket = FindObjectOfType<Rocket>();
            rocket.MovementSpeed += addedSpeed;
            Debug.Log(rocket.MovementSpeed);
        }
    }
}
