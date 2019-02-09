using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SlowingCase : ItemBase
{
    [SerializeField]
    GameObject slowingObject;
    [SerializeField]
    float ExpandValue;

    Transform slowingSpawn;

    Tween tween;
    Vector3 directionFall;
    Vector3 oldPosition;
    Quaternion oldRotation;

    protected override void Awake()
    {
        base.Awake();
        oldPosition = GetComponent<Transform>().position;
        oldRotation = GetComponent<Transform>().rotation;
        slowingSpawn = transform.GetChild(0).GetComponent<Transform>();
    }



    public override void OnSpawn()
    {
        base.OnSpawn();
        StopCoroutine(MoveSlowing());
        collider.enabled = true;
        tween.Pause();
        transform.rotation = oldRotation;
        transform.position = oldPosition;
    }

    public override void OnTake(IPlayer player)
    {
        base.OnTake(player);
        collider.enabled = false;
        directionFall = player.gameObject.GetComponent<PlayerController>().Direction;
        transform.rotation = Quaternion.LookRotation(directionFall);
        tween = transform.DORotate(new Vector3(90, 0, 0), 0.5f).SetRelative();
    }

    GameObject slowing;
    public override void Effect(IPlayer _player)
    {
        slowing = Instantiate(slowingObject, slowingSpawn.position, Quaternion.LookRotation(directionFall));
        slowing.transform.DOScaleZ(ExpandValue, 1);
        StartCoroutine(MoveSlowing());
    }

    IEnumerator MoveSlowing()
    {
        while (true)
        {
            slowing.transform.position = transform.position;
            yield return null;
        }
    }
}
