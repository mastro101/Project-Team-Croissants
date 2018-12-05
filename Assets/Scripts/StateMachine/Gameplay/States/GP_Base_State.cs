using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public abstract class GP_Base_State : StateBase
    {
        protected GameplaySMContext context;

        protected abstract string stateName { get; }

        public override IState Setup(IStateMachineContext _context)
        {
            context = _context as GameplaySMContext;
            return this;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Enter: " + stateName);
        }

        public override void Tick()
        {
            base.Tick();
            Debug.Log("On: " + stateName);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Exit: " + stateName);
        }
    }
}
