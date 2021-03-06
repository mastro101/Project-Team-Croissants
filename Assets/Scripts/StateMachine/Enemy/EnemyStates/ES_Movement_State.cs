﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StateMachine.Enemy
{
    public class ES_Movement_State : ES_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Movement";
            }
        }

        public override void Enter()
        {
            base.Enter();
            if (context.StateInt < context.LimitChangeState || context.LimitChangeState < 0)
            {
                context.AbilityState();
            }
        }

        public override void Tick()
        {
            base.Tick();
            context.Enemy.Movement();
        }
    }
}



