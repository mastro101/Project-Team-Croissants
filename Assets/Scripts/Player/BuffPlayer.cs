using UnityEngine;
using System.Collections;
using StateMachine.Gameplay;

[RequireComponent(typeof(IPlayer))]
public class BuffPlayer : MonoBehaviour
{
    IPlayer player;

    float variable;
    float second;
    public StatusCondiction statusCondiction { get; private set; }

    GameplaySM gameplaySM;
    BuffEffects buffEffects;
    GameObject effect;

    public void SetBuff(StatusCondiction _condiction, float _variable, float sec)
    {
        gameplaySM = FindObjectOfType<GameplaySM>();
        buffEffects = FindObjectOfType<BuffEffects>();
        gameplaySM.endBattle += restartStatistic;
        statusCondiction = _condiction;
        variable = _variable;
        second = sec;
        player = GetComponent<IPlayer>();
        StartBuff();
    }

    public void StartBuff()
    {
        switch (statusCondiction)
        {
            case StatusCondiction.Slow:
                slow();
                break;
            case StatusCondiction.Invert:
                invert();
                break;
            default:
                break;
        }
        StartCoroutine(stopBuff(player));
    }

    public void RestartCorutine(float sec)
    {
        StopCoroutine(stopBuff(player));
        second = sec;
        //StartCoroutine(stopBuff(player));
    }

    public void restartStatistic()
    {
        switch (statusCondiction)
        {
            case StatusCondiction.Slow:
                player.MovementSpeed = player.OriginalSpeed;
                break;
            case StatusCondiction.Invert:
                player.gameObject.GetComponent<PlayerController>().InverterVector = 1;
                player.transform.Rotate(0, 180, 0);
                break;
            default:
                break;
        }
        gameplaySM.endBattle -= restartStatistic;
        Destroy(effect);
        Destroy(this);
    }

    void slow()
    {        
        if (buffEffects != null)
        {
            if (variable > 0)
                SpawnEffect(buffEffects.SlowEffect);
            else
                SpawnEffect(buffEffects.AcceleratorEffect);
        }
        player.MovementSpeed -= variable;
    }

    void invert()
    {
        player.gameObject.GetComponent<PlayerController>().InverterVector = -1;
        player.transform.Rotate(0, 180, 0);
        if (buffEffects != null)
            SpawnEffect(buffEffects.StunEffect);
    }

    void SpawnEffect(GameObject _effect)
    {
        if (_effect != null)
            effect = Instantiate(_effect, transform.position + new Vector3(0, 3.5f, 0), Quaternion.Euler(0, 0, 180), transform);
    }

    IEnumerator stopBuff(IPlayer player)
    {
        yield return new WaitForSeconds(second);
        restartStatistic();
    }
}

public enum StatusCondiction
{
    Slow, Invert,
}
