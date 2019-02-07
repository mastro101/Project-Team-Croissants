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
            for (int i = 0; i < 3; i++)
            {
                context.WinCheckImageP1[i].SetActive(false);
                context.WinCheckImageP2[i].SetActive(false);
            }
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