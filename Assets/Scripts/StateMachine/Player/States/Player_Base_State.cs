using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Player
{
    public abstract class Player_Base_State : StateBase
    {
        protected PlayerSMContext context;

        public override IState Setup(IStateMachineContext _context)
        {
            context = _context as PlayerSMContext;
            return this;
        }
    }
}