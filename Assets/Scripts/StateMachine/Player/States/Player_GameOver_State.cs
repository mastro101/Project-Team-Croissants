using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_GameOver_State : Player_Base_State
    {
        protected override string stateName
        {
            get
            {
                return context.Player.ToString() + " GameOver";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.PlayerController.ResetCooldown();
            context.Player.transform.position = new Vector3(200,-200,200);
            context.ExitState();
        }
    }
}