using UnityEngine;
using System.Collections;

public class Slowing : ItemBase
{
    float OriginalSpeed;

    public override void Effect(IPlayer _player)
    {
        _player.MovementSpeed -= (_player.MovementSpeed / 100) * 20;
    }

    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {

        }
    }
}
