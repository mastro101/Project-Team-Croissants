using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Enemy
{

    public abstract class ES_Base_State : StateBase {

        protected EnemySMContext context;
    


        public override IState Setup(IStateMachineContext _context)
        {
            context = _context as EnemySMContext;
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