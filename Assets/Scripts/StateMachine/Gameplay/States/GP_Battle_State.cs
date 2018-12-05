using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_Battle_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Battle";
            }
        }

        public override void Tick()
        {
            base.Tick();
            context.Players[0].PlayerInput();
            context.Players[1].PlayerInput();
        }
    }
}