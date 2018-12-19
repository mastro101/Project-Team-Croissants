﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Enemy
{

    public class EnemySM : StateMachineBase
    {
        protected override void Start()
        {
            currentContext = new EnemySMContext()
            {
                ExitState = goNext,
            };




        }
            void goNext()
            {
                SM.SetTrigger("Exit");
            }

    }
        public class EnemySMContext : IStateMachineContext
        {
            public Action ExitState;

        }

}