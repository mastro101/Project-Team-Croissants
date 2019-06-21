using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSoundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("FallingSound");
    }
}
