using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    float LoopTime;
    [SerializeField]
    Vector2 direction;

    Tween offsetTween;

    void Start()
    {
        offsetTween = GetComponent<Renderer>().material.DOOffset(direction, LoopTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}
