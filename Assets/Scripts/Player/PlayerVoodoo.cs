using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerVoodoo : PlayerBase
{
    [SerializeField]
    GameObject Graphic;
    [SerializeField]
    float effectTime;

    bool isEffect;

    public override int ID
    {
        get
        {
            return 1;
        }
    }

    public override string Name
    {
        get
        {
            return "Voodoo";
        }
    }

    public override void Ability()
    {
        //Graphic.GetComponent<MeshRenderer>().material.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo);
        isEffect = true;
        StartCoroutine(StopEffect());
        Debug.Log(isEffect);
        SM.SetBool("Ability", false);
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(effectTime);
        isEffect = false;
        Debug.Log(isEffect);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (isEffect)
        {
            if (player != null)
            {
                Debug.Log("playeeeeeeeeeeeeeeeeer");
                player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Invert, 0, 6);
            }
        }
    }
}
