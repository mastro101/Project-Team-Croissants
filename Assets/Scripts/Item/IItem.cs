using UnityEngine;
using System.Collections;

public interface IItem
{
    GameObject gameObject { get; }
    Transform transform { get; }
    Collider collider { get; }
    MeshRenderer meshRenderer { get; }
    void Effect(IPlayer player);
    void OnSpawn(IPlayer player);
    void OnTake(IPlayer player);
}
