using UnityEngine;
using System.Collections;

namespace StateMachine.Player
{
    public class Player_Ability_State : Player_Base_State
    {
        protected override string stateName
        {
            get
            {
                return context.Player.ToString() + " Ability";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.Player.Ability();
        }

    }
}