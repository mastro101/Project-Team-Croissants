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


    IPlayer playerToFollow;
    public override IPlayer PlayerToFollow
    {
        get
        {
            return playerToFollow;
        }
        set
        {
            playerToFollow = value;
        }
    }

    private void Update()
    {
        if (PlayerToFollow != null)
            transform.LookAt(PlayerToFollow.transform);
    }

    float speed;
    public override void Movement()
    {
        speed = MovementSpeed * Time.deltaTime;
        if (PlayerToFollow != null)
            transform.position = Vector3.MoveTowards(transform.position, PlayerToFollow.transform.position, speed);
    }


}
