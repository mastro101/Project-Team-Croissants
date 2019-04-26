using UnityEngine;
using UnityEditor;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class TimerTrap : Slowing
{
    [SerializeField]
    float timer, effectTime;

    protected override bool EffectOnTriggerEnter
    {
        get
        {
            return false;
        }
    }

    List<IPlayer> players = new List<IPlayer>();

    public IPlayer MyPlayer;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Effect());
    }

    protected override void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            players.Add(player);
        }
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(timer);
        foreach (IPlayer player in players)
        {
            if (player != MyPlayer)
                Effect(player);
        }
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            players.Remove(player);
        }
    }

    public override void OnSpawn()
    {
        StopCoroutine(Effect());
        base.OnSpawn();
    }

    public void SetTimer(float _timer, float _effectTime)
    {
        timer = _timer;
        effectTime = _effectTime;
    }
}