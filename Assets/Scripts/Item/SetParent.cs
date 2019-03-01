using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{

    public LayerMask mask;

    
    private void Start()
    {
        Ray ray = new Ray(transform.position + new Vector3(0,1.5f,0), Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f, mask))
        {
            Debug.Log(hit.transform.gameObject.layer);
            transform.SetParent(hit.transform);
            Debug.DrawRay(ray.origin, hit.point, Color.red);
        }
        else
            Debug.DrawRay(ray.origin, hit.point, Color.green);
    }
}
