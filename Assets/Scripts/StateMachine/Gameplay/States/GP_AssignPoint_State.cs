using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_AssignPoint_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "AssignPoint";
            }
        }

        public override void Enter()
        {
            base.Enter();

        }
    }
}