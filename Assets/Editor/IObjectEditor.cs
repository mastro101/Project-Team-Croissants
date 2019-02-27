using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SlowingCase))]
public class IObjectEditor : Editor
{
    //public override void OnInspectorGUI()
    //{
    //    base.OnInspectorGUI();
    //
    //    Debug.Log("bsdhbisvn");
    //
    //    SlowingCase Object = target as SlowingCase;
    //
    //    Ray ray = new Ray(Object.transform.position, Vector3.down);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit, 1, 9))
    //    {
    //        Object.transform.SetParent(hit.transform);
    //        Debug.DrawRay(ray.origin, hit.point, Color.red);
    //    }
    //    else
    //        Debug.DrawRay(ray.origin, hit.point, Color.green);
    //}
}