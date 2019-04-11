using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*public Transform playerpos;
    
    // Update is called once per frame
    void Update () {
        gameObject.transform.position = playerpos.transform.position + offset;
	}*/

    public List<Transform> targets;
    public float smoothTime = 0.5f;
    public float maxZoom;
    public float minZoom;
    public float zoomlimiter;
    private Vector3 velocity;
    public Camera cam;

    private void LateUpdate()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        Vector3 centerPoin = GetCenterPoint();
        transform.position = Vector3.SmoothDamp(transform.position, centerPoin, ref velocity, smoothTime);
    }
    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.Remove(targets[i]);
            }
            else
            {
                bounds.Encapsulate(targets[i].position);
            }
        }

        return bounds.center;
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetBoundWidth() / zoomlimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    private float GetBoundWidth()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }
}
