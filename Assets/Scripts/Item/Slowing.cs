using UnityEngine;
using System.Collections;

public class Slowing : ItemBase
{
    [SerializeField] GameObject ParentGO;
    [SerializeField]
    float second = 2;
    [Range(-100, 100)]
    [SerializeField]
    protected int PercentSlow;
    [SerializeField]
    bool immediatelyEffect;
    bool isEffect;

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
        if (immediatelyEffect)
            isEffect = true;
        else
            isEffect = false;
    }

    public override void Effect(IPlayer _player)
    {
        if (isEffect)
        {
            if (_player.gameObject.GetComponent<BuffPlayer>() == null)
            {
                _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Slow, (_player.MovementSpeed / 100) * PercentSlow, second);
            }
            else
            {
                BuffPlayer buff = _player.gameObject.GetComponent<BuffPlayer>();
                if (buff.statusCondiction == StatusCondiction.Slow)
                {
                    buff.RestartCorutine(second);
                    buff.restartStatistic();
                    Destroy(buff);
                    _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Slow, (_player.MovementSpeed / 100) * PercentSlow, second);
                }
                else
                    _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Slow, (_player.MovementSpeed / 100) * PercentSlow, second);
            }
        }
        else
        {
            isEffect = true;
            dontEffect = true;
        }
    }

    bool dontEffect = false;
    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null && !dontEffect)
        {
            Effect(player);
        }
        else if (dontEffect)
            dontEffect = true;
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        //gameplaySM.endBattle -= OnSpawn;
        if (immediatelyEffect)
            isEffect = true;
        else
            isEffect = false;

        //Fixare
        Destroy(ParentGO);
    }
}
