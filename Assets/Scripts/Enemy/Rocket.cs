using UnityEngine;
using System.Collections;
using UnityEditor;
using DG.Tweening;

public class Rocket : EnemyBase
{
    [Range(0,100)]
    [SerializeField]
    float percentSpeed, PercentScale;

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

   //private void Update()
   //{
   //    if (PlayerToFollow != null)
   //    {
   //        //transform.LookAt(PlayerToFollow.transform); 
   //    }
   //}

    float speed;
    public override void Movement()
    {
        base.Movement();
        speed = MovementSpeed * Time.deltaTime;
        if (PlayerToFollow != null)
        {
            transform.position += transform.forward * speed;
            Vector3 targetPos = PlayerToFollow.transform.position - transform.position + new Vector3(0, 1, 0);
            Quaternion rotation = Quaternion.LookRotation(targetPos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationSpeed);
            //transform.position = Vector3.MoveTowards(transform.position, PlayerToFollow.transform.position, speed);
        }
        

    }

    public override void Ability()
    {
        base.Ability();
        MovementSpeed += MovementSpeed / 100 * percentSpeed;
        transform.DOScale(transform.lossyScale / 100 * PercentScale, 1).SetRelative();
        
    }

}
