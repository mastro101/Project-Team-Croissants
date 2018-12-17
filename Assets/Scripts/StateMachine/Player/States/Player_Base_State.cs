using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Player
{
    public abstract class Player_Base_State : StateBase
    {
        public override IState Setup(IStateMachineContext _context)
        {
            throw new System.NotImplementedException();
        }
    }
}