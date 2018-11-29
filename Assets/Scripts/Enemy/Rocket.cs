using UnityEngine;
using System.Collections;

public class Rocket : EnemyBase
{
    [SerializeField]
    float movementSpeed;
    public override float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
            movementSpeed = value;
        }
    }

    [SerializeField]
    BasePlayer playerToFollow;
    public override IPlayer PlayerToFollow
    {
        get
        {
            return playerToFollow;
        }
    }

    private void Update()
    {
        if (PlayerToFollow != null)
            transform.LookAt(PlayerToFollow.transform);
    }

    float speed;
    private void FixedUpdate()
    {
        speed = MovementSpeed * Time.deltaTime;
        if (PlayerToFollow != null)
            transform.position = Vector3.MoveTowards(transform.position, PlayerToFollow.transform.position, speed);
    }
}
