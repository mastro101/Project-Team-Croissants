using UnityEngine;
using System.Collections;

public abstract class PowerUpBase : MonoBehaviour , IPowerUp
{
    public abstract void Effect(IPlayer _player);

    /// <summary>
    /// Chiamato quando un Player entra nell'area di trigger
    /// </summary>
    /// <param name="_player"></param>
    public virtual void OnTake()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            OnTake();
            Effect(player);
            Destroy(gameObject);
        }
    }
}
