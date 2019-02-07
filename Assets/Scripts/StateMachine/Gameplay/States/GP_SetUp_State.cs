using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_SetUp_State : GP_Base_State
    {
        [SerializeField]
        GameObject tutorialPanel;

        GameObject tutorialInScene;

        protected override string stateName
        {
            get
            {
                return "SetUP";
            }
        }

        public override void Enter()
        {
            base.Enter();
            tutorialInScene = Instantiate(tutorialPanel, context.Canvas.transform);
            tutorialInScene.SetActive(true);
        }

        public override void Tick()
        {
            base.Tick();
            if (Input.anyKey)
            {
                context.BaseExitState();
            }
        }

        public override void Exit()
        {
            base.Exit();
            tutorialInScene.SetActive(false);
        }
    }
}