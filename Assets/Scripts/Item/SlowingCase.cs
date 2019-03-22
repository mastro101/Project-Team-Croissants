using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SlowingCase : ItemBase
{
    [SerializeField]
    GameObject slowingObject;
    [SerializeField]
    float ExpandValue;

    [SerializeField]
    Transform slowingSpawn;

    Tween tween;
    Vector3 directionFall;
    Quaternion oldRotation;

    protected override bool EffectOnTriggerEnter
    {
        get
        {
            return true;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        oldRotation = GetComponent<Transform>().rotation;
    }



    public override void OnSpawn()
    {
        base.OnSpawn();
        StopCoroutine(MoveSlowing());
        collider.enabled = true;
        tween.Pause();
        transform.rotation = oldRotation;
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
    Vector3 spawnPosition;


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
            slowing.transform.position = slowingSpawn.position + (Vector3.up * slowingSpawn.localPosition.y);
            yield return null;
        }
    }
}
