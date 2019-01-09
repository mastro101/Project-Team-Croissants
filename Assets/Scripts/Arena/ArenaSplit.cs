using UnityEngine;
using System.Collections;
using DG.Tweening;

public class ArenaSplit : MonoBehaviour
{
    [SerializeField]
    Transform upLeft, upRight, downLeft, downRight;
    Vector3 oldUpLeft, oldUpRight, oldDownLeft, oldDownRight;

    [SerializeField]
    float EndSplitTime;
    [SerializeField]
    float distance;

    [SerializeField]
    float waitTime;

    Tween[] tween = new Tween[4];

    /// <summary>
    /// separa l'arena verticalmente e successivamente sopra e sotto
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveRL()
    {
        if (upLeft != null && upRight != null && downLeft != null && downRight != null)
        {
            yield return new WaitForSeconds(waitTime);
            // move left
            tween[0] = upLeft.DOMove(Vector3.left * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            tween[1] = downLeft.DOMove(Vector3.left * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            // move right
            tween[2] = upRight.DOMove(Vector3.right * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            tween[3] = downRight.DOMove(Vector3.right * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            StartCoroutine(MoveUD());            
        }
    }

    private void Awake()
    {
        oldUpLeft = upLeft.position;
        oldUpRight = upRight.position;
        oldDownLeft = downLeft.position;
        oldDownRight = downRight.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tween[0].Pause();
            tween[1].Pause();
            tween[2].Pause();
            tween[3].Pause();
        }
    }

    /// <summary>
    /// Resetta animazioni e posizioni dei pezzi dell'arena
    /// </summary>
    public void Setup()
    {
        StopAllCoroutines();
        tween[0].Pause();
        tween[1].Pause();
        tween[2].Pause();
        tween[3].Pause();
        upLeft.position = oldUpLeft;
        upRight.position = oldUpRight;
        downLeft.position = oldDownLeft;
        downRight.position = oldDownRight;
    }

    IEnumerator MoveUD()
    {
        if (upLeft != null && upRight != null && downLeft != null && downRight != null)
        {
            yield return new WaitForSeconds(waitTime);
            // move up
            tween[0] = upLeft.DOMove(Vector3.forward * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            tween[1] = upRight.DOMove(Vector3.forward * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);

            // move down
            tween[2] = downLeft.DOMove(Vector3.back * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
            tween[3] = downRight.DOMove(Vector3.back * distance, EndSplitTime).SetRelative().SetAutoKill(false).SetEase(Ease.Linear);
        }
    }
}
