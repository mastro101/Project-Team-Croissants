using UnityEngine;
using System.Collections;

public abstract class PowerUpBase : ItemBase , IItem
{
    public override void OnSpawn(IPlayer player)
    {
        base.OnSpawn(player);
        if (!collider.enabled)
            collider.enabled = true;
        if (!meshRenderer.enabled)
            meshRenderer.enabled = true;
    }
}
