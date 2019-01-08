using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovDownLeft : MonoBehaviour
{


    public GameObject wall;

    public Vector3 StartPos;
    public Vector3 EndPos;

    public float distancebetween = 2f;

    public float lerptimer = 2;


    public float currentLerpTimer;

    private void Start()
    {
        StartPos = wall.transform.position;
        EndPos = wall.transform.position + new Vector3(1, 0, -1) * distancebetween;
    }

    private void Update()
    {
        currentLerpTimer += Time.deltaTime;
        if (currentLerpTimer >= lerptimer)
        {
            currentLerpTimer = lerptimer;
        }

        float perc = currentLerpTimer / lerptimer;

        wall.transform.position = Vector3.Lerp(StartPos, EndPos, perc);
    }


}
