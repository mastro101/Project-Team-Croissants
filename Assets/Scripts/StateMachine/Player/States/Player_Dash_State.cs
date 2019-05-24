using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_Dash_State : Player_Base_State
    {
        float cooldownDurationTimer;

        protected override string stateName
        {
            get
            {
                return context.Player.ToString() + " Dash";
            }
        }

        public override void Enter()
        {
            base.Enter();
            cooldownDurationTimer = 0;
            context.PlayerController.canMove = false;
            context.Player.rigidbody.useGravity = false;
            context.Player.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            context.PlayerController.canPush = true;
            FindObjectOfType<AudioManager>().Play("Dash");
        }

        public override void Tick()
        {
            base.Tick();
            context.PlayerController.Dash();

            cooldownDurationTimer += Time.deltaTime;
            if(cooldownDurationTimer >= context.Player.DashDuration)
            {
                context.ExitState();
            }

        }

        public override void Exit()
        {
            base.Exit();
            context.PlayerController.canMove = true;
            context.Player.rigidbody.useGravity = true;
            context.PlayerController.canPush = false;
            context.Player.rigidbody.freezeRotation = false;
            context.Player.rigidbody.constraints = RigidbodyConstraints.None;
            context.Player.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        }

    }
}