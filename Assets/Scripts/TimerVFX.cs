using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem VFX;
    [SerializeField] float timerToPlay;
    [Space]
    [SerializeField] bool neverStop = true;
    [SerializeField] float timerToStop;

    private void Awake()
    {
        VFX.Stop();
    }

    private void Start()
    {
        StartCoroutine(StartVFX());
    }

    IEnumerator StartVFX()
    {
        yield return new WaitForSeconds(timerToPlay);
        VFX.Play();
        if (!neverStop)
            StartCoroutine(StopVFX());
    }

    IEnumerator StopVFX()
    {
        yield return new WaitForSeconds(timerToStop);
        VFX.Stop();
    }

}
