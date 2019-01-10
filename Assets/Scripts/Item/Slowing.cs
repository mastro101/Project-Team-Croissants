using UnityEngine;
using System.Collections;

public class Slowing : ItemBase
{
    [SerializeField]
    float second = 2;

    public override void Effect(IPlayer _player)
    {
        if (_player.gameObject.GetComponent<BuffPlayer>() == null)
        {
            _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Slow, (_player.MovementSpeed / 100) * 20, second);
        }
        else
        {
            BuffPlayer buff = _player.gameObject.GetComponent<BuffPlayer>();
            if (buff.statusCondiction == StatusCondiction.Slow)
                buff.RestartCorutine(second);
            else
                _player.gameObject.AddComponent<BuffPlayer>().SetBuff(StatusCondiction.Slow, (_player.MovementSpeed / 100) * 20, second);
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
        gameplaySM.endBattle -= OnSpawn;
        Destroy(gameObject);
    }
}
