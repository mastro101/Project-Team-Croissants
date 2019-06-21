using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    [SerializeField] GameObject GO;
    [SerializeField] float timerToDestroy;

    private void Start()
    {
        StartCoroutine(startTimer());
    }

    IEnumerator startTimer()
    {
        yield return new WaitForSeconds(timerToDestroy);
        Destroy(GO);
    }
}
