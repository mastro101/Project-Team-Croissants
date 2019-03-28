using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Enemy
{

    public class EnemySM : StateMachineBase
    {
        [SerializeField]
        int limitStateChange;

        protected override void Start()
        {
            currentContext = new EnemySMContext()
            {
                ExitState = goNext,
                AbilityState = setAbility,
                Enemy = gameObject.GetComponent<IEnemy>(),
                LimitChangeState = limitStateChange,
                StateInt = 0,
            };
            base.Start();
        }

        void goNext()
        {
            SM.SetTrigger("Exit");
        }

        void setAbility()
        {
            SM.SetTrigger("Ability");
        }
    }

    public class EnemySMContext : IStateMachineContext
    {
        public Action ExitState, AbilityState;
        public IEnemy Enemy;
        public int LimitChangeState, StateInt;
    }

}
