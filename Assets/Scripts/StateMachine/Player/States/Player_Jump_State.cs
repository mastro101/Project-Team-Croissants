using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_Jump_State : Player_Base_State
    {
        protected override string stateName
        {
            get
            {
                return context.Player.ToString() + " Jump";
            }
        }

        Ray rayGround;
        PlayerController playerController;
        RaycastHit hitGround;
        float range;

        public override void Enter()
        {
            base.Enter();
            playerController = context.Player.gameObject.GetComponent<PlayerController>();
            playerController.Jump();
            //if (playerController.groundDetector.position != null)
            //{
            //    rayGround = new Ray(playerController.groundDetector.position, Vector3.down);
            //}
        }

        public override void Tick()
        {
            base.Tick();
            //if (playerController.groundDetector.position != null)
            //{
            //    if (Physics.Raycast(playerController.groundDetector.position, Vector3.down, out hitGround, 1f))
            //    {
            //        Debug.Log(hitGround.collider.name);
            //        Debug.DrawRay(playerController.groundDetector.position, Vector3.down, Color.blue);
            //
            //        if (hitGround.collider != null)
            //        {
            //            //context.Player.SM.SetBool("Jump", false);
            //            Debug.Log("Jump effettuato");
            //        }
            //    }
            //}
        }
    }
}