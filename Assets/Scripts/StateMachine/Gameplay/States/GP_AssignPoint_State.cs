using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_AssignPoint_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "AssignPoint";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.EndRoundPanel.SetActive(true);
            for (int i = 0; i < context.P1.Points; i++)
            {
                context.WinCheckImageP1[i].SetActive(true);
            }
            for (int i = 0; i < context.P2.Points; i++)
            {
                context.WinCheckImageP2[i].SetActive(true);
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
        }
    }
}