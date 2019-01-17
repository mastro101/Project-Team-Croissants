using UnityEngine;
using System.Collections;

public class Pit : EnemyBase
{
    protected override void OnTriggerEnter(Collider collider)
    {
        base.OnTriggerEnter(collider);
        IItem item = collider.GetComponent<IItem>();
        if (item != null)
            Destroy(item.gameObject);
    }
}
