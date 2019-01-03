using UnityEngine;
using System.Collections;

public abstract class PowerUpBase : MonoBehaviour , IPowerUp
{
    public Collider collider { get { return GetComponent<Collider>(); } }

    public MeshRenderer meshRenderer { get { return GetComponent<MeshRenderer>(); } }

    public abstract void Effect(IPlayer _player);

    /// <summary>
    /// Chiamato quando finisce un round
    /// </summary>
    public virtual void OnSpawn()
    {
        if (!collider.enabled)
            collider.enabled = true;
        if (!meshRenderer.enabled)
            meshRenderer.enabled = true;
    }

    /// <summary>
    /// Chiamato quando un Player entra nell'area di trigger
    /// </summary>
    /// <param name="_player"></param>
    public virtual void OnTake(IPlayer player)
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            Effect(player);
            OnTake(player);
        }
    }
}
