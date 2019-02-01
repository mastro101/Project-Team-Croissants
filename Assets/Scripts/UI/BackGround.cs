using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    float LoopTime;

    Tween offsetTween;

    void Start()
    {
        offsetTween = GetComponent<Renderer>().material.DOOffset(new Vector2(-1,-1), LoopTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}
