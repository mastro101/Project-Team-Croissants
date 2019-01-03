using UnityEngine;
using System.Collections;

public class RocketAccelerator : PowerUpBase
{
    [SerializeField]
    float addedSpeed;
    EnemyBase[] enemies;
    Rocket rocket;

    private void Awake()
    {
        enemies = FindObjectsOfType<EnemyBase>();
    }
    private void Start()
    {
        foreach (EnemyBase enemy in enemies)
        {
            enemy.HitPlayer += spawn;
        }
        rocket = FindObjectOfType<Rocket>();
    }

    void spawn(IPlayer player)
    {
        OnSpawn();
    }

    public override void OnTake(IPlayer player)
    {
        base.OnTake(player);
        if (player != rocket.PlayerToFollow)
        {
            collider.enabled = false;
            meshRenderer.enabled = false;
        }
    }

    
    public override void Effect(IPlayer _player)
    {
        if (_player != rocket.PlayerToFollow)
        {            
            rocket.MovementSpeed += addedSpeed;
        }
    }

}
