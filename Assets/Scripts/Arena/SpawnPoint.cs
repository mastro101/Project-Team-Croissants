using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform[] PlayerSpawn;
    public ParticleSystem[] SpawnVFX;

    public void Spawn(int l)
    {
        for (int i = 0; i < l; i++)
        {
            SpawnVFX[i].Play();
        }
    }
}