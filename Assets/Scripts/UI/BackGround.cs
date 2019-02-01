using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    Material BackGroundMaterial;
    [SerializeField]
    float LoopTime;

    Tween offsetTween;

    void Update()
    {
        offsetTween = BackGroundMaterial.DOOffset(Vector2.right, LoopTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).Play();
    }
}
