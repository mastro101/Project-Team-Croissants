using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public abstract class GP_Base_State : StateBase
    {
        protected GameplaySMContext context;

        

        public override IState Setup(IStateMachineContext _context)
        {
            context = _context as GameplaySMContext;
            return this;
        }

        public override void Enter()
        {
            base.Enter();

        }

        public override void Tick()
        {
            base.Tick();

        }

        public override void Exit()
        {
            base.Exit();
            
        }
    }
}
