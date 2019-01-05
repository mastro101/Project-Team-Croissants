using UnityEngine;
using System.Collections;

public class SlowingCase : ItemBase
{
    [SerializeField]
    GameObject slowingObject;
    Transform slowingSpawn;

    Vector3 directionFall;
    Vector3 oldPosition;
    Quaternion oldRotation;

    protected override void Awake()
    {
        base.Awake();
        oldPosition = GetComponent<Transform>().position;
        oldRotation = GetComponent<Transform>().rotation;
        slowingSpawn = gameObject.GetComponentInChildren<Transform>();
    }

    public override void OnSpawn(IPlayer player)
    {
        base.OnSpawn(player);
        collider.enabled = true;
        transform.rotation = oldRotation;
        transform.position = oldPosition;
    }

    public override void OnTake(IPlayer player)
    {
        base.OnTake(player);
        collider.enabled = false;
        directionFall = player.gameObject.GetComponent<PlayerController>().Direction;
        transform.rotation = Quaternion.LookRotation(directionFall);
        transform.Rotate(90, 0, 0);
    }

    public override void Effect(IPlayer _player)
    {
        Instantiate (slowingObject, slowingSpawn);
    }
}
