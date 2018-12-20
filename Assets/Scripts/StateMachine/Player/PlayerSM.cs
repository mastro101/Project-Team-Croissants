using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Player
{
    
    public class PlayerSM : StateMachineBase {

        protected override void Start()
        {
            currentContext = new PlayerSMContext()
            {
                Player = gameObject.GetComponent<IPlayer>(),
                ExitState = GoNext,
            };
            base.Start();
        }

        void GoNext()
        {
            SM.SetTrigger("Exit");
        }
    }

    public class PlayerSMContext : IStateMachineContext
    {
        public Action ExitState;
        public IPlayer Player;
    }
}