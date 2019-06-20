using UnityEngine;
using System.Collections;

namespace StateMachine.Menu
{
    public abstract class Menu_Base_State : StateBase
    {
        protected MenuSMContext context;

        public override IState Setup(IStateMachineContext _context)
        {
            context = _context as MenuSMContext;
            return this;
        }

        public override void Enter()
        {
            base.Enter();
            context.GoNext(-1);
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
