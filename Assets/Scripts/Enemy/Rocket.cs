using UnityEngine;
using System.Collections;
using UnityEditor;

public class Rocket : EnemyBase
{
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
        {
            Vector3 targetPos = PlayerToFollow.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationSpeed);
            //transform.LookAt(PlayerToFollow.transform);
        }
    }

    float speed;
    public override void Movement()
    {
        base.Movement();
        speed = MovementSpeed * Time.deltaTime;
        if (PlayerToFollow != null)
        {
            transform.position += transform.forward * speed;
            //transform.position = Vector3.MoveTowards(transform.position, PlayerToFollow.transform.position, speed);
        }
        

    }

   
}
