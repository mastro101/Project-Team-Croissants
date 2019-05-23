using UnityEngine;
using System.Collections;

public class Slowing : ItemBase
{
    [SerializeField]
    float second = 2;
    [Range(-100, 100)]
    [SerializeField]
    protected int PercentSlow;

    protected override bool EffectOnTriggerEnter
    {
        get
        {
            return true;
        }
    }

    public override void Effect(IPlayer _player)
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

    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            Effect(player);
        }
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        //gameplaySM.endBattle -= OnSpawn;
        Destroy(gameObject);
    }
}
