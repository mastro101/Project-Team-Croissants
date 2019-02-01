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

    public void SetBuff(StatusCondiction _condiction, float _variable, float sec)
    {
        gameplaySM = FindObjectOfType<GameplaySM>();
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
        StartCoroutine(stopBuff(player));
    }

    void restartStatistic()
    {
        switch (statusCondiction)
        {
            case StatusCondiction.Slow:
                player.MovementSpeed = player.OriginalSpeed;
                break;
            case StatusCondiction.Invert:
                player.gameObject.GetComponent<PlayerController>().InverterVector = 1;
                break;
            default:
                break;
        }
        gameplaySM.endBattle -= restartStatistic;
        Destroy(this);
    }

    void slow()
    {
        player.MovementSpeed -= variable;
    }

    void invert()
    {
        player.gameObject.GetComponent<PlayerController>().InverterVector = -1;
        Debug.Log("inverted");
    }

    IEnumerator stopBuff(IPlayer player)
    {
        yield return new WaitForSeconds(second);
        restartStatistic();
    }

}

public enum StatusCondiction{
    Slow, Invert,
}
