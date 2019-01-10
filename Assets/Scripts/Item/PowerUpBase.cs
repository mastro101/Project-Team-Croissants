using UnityEngine;
using System.Collections;

public abstract class PowerUpBase : ItemBase , IItem
{
    public override void OnSpawn()
    {
        base.OnSpawn();
        if (!collider.enabled)
            collider.enabled = true;
        if (!meshRenderer.enabled)
            meshRenderer.enabled = true;
    }
}
