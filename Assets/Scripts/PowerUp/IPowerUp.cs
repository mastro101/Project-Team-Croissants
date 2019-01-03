using UnityEngine;
using System.Collections;

public interface IPowerUp
{
    Collider collider { get; }
    MeshRenderer meshRenderer { get; }
    void Effect(IPlayer player);
    void OnSpawn();
    void OnTake(IPlayer player);
}
