using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpritePlayerStretch : MonoBehaviour
{

    public GameObject highlightedPlayer;

    Tween tween;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //highlightedPlayer.transform.DOScale(0.4f, 3).

        Gira();


    }


    void Gira()
    {
        //tween.SetLoops<Tween>(-1, LoopType.Yoyo);
        tween = highlightedPlayer.transform.DOScale(0.3f, 1).SetLoops<Tween>(-1, LoopType.Yoyo);
    }

}
