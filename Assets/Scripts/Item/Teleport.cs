using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {


    [SerializeField]
    Transform tp1destination;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = tp1destination.transform.position;
       // gameObject.SetActive(false);
    }
}
