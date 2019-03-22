using UnityEngine;
using System.Collections;

public class RocketAccelerator : PowerUpBase
{
    [SerializeField]
    float addedSpeed;
    Rocket rocket;

    protected override bool EffectOnTriggerEnter
    {
        get
        {
            return true;
        }
    }

    protected override void Start()
    {
        base.Start();
        rocket = FindObjectOfType<Rocket>();
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

    //GIRA GIRA
    private void Update()
    {
        giragira();
    }

    void giragira()
    {
        transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
    }

}
