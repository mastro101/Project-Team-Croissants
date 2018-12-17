using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Player
{
    
    public class PlayerSM : StateMachineBase {

        [SerializeField]
        IPlayer player;

        protected override void Start()
        {
            currentContext = new PlayerSMContext()
            {
                Player = player,
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