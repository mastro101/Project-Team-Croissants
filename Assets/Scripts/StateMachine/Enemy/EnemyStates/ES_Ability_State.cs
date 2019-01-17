using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace StateMachine.Enemy
{
    public class ES_Ability_State : ES_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Ability";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.Enemy.Ability();
        }
    }
}

