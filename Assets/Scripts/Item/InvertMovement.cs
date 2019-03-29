using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertMovement : ItemBase
{
    float timer, effectTime;

    protected override bool EffectOnTriggerEnter
    {
        get
        {
            return false;
        }
    }

    List<IPlayer> players = new List<IPlayer>();

    protected override void Start()
    {
        base.Start();
        StartCoroutine(Effect());
    }

    public override void Effect(IPlayer _player)
    {
        _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Invert, 0, 6);
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

    public void SetTimer(float _timer, float _effectTime)
    {
        timer = _timer;
        effectTime = _effectTime;
    }
}
