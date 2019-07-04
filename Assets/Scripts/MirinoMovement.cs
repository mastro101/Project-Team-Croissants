using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirinoMovement : MonoBehaviour
{
    [SerializeField]
    Transform RotateObject, FireBallSprite;
    [SerializeField]
    int DegreesPerSec;

    Camera camera;

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        RotateObject.RotateAround(transform.parent.transform.position, Vector3.up, DegreesPerSec * Time.deltaTime);
        FireBallSprite.LookAt(camera.transform);
    }
}
