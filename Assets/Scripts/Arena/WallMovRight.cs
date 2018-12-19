using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovRight : MonoBehaviour
{


    public GameObject wall;

    public Vector3 StartingPosition;
    public Vector3 firstTransition;

    public float distance = 2f;

    public float lerpTime = 2;


    public float currentLerpTime;

    private void Start()
    {
        StartingPosition = wall.transform.position;
        firstTransition = wall.transform.position + Vector3.right * distance;
    }

    private void Update()
    {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        float perc = currentLerpTime / lerpTime;

        wall.transform.position = Vector3.Lerp(StartingPosition, firstTransition, perc);
    }


}
