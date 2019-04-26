using UnityEngine;
using System.Collections;

public class PlayerPunkTrinity : PlayerBase
{
    [SerializeField]
    float effectTime, timerAbility;

    [SerializeField]
    GameObject trapPrefab;

    BuffEffects effect;

    public override int ID
    {
        get
        {
            return 3;
        }
    }

    public override string Name
    {
        get
        {
            return "Trinity";
        }
    }

    GameObject _effect;
    public override void Ability()
    {
        base.Ability();
        //Graphic.GetComponent<MeshRenderer>().material.DOFade(0, 1).SetLoops(-1, LoopType.Yoyo);
        effect = FindObjectOfType<BuffEffects>();
        FindObjectOfType<AudioManager>().Play("PunkAbility");
        _effect = Instantiate(effect.InvertAbility, transform.position + new Vector3(0, 3.5f, 0), transform.rotation, transform);
        Instantiate(trapPrefab, transform.position + (Vector3.up * 0), Quaternion.Euler(Vector3.zero), transform).GetComponent<TimerTrap>().MyPlayer = this;
        /*isEffect = true;
        StartCoroutine(StopEffect());
        Debug.Log(isEffect);*/
        SM.SetBool("Ability", false);
    }
}
