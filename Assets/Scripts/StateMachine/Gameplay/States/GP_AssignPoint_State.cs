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

        int pointP1, pointP2;

        public override void Enter()
        {
            FindObjectOfType<AudioManager>().Play("EndRound");
            base.Enter();
            pointP1 = 0;
            pointP2 = 0;
            context.EndRoundPanel.SetActive(true);
            for (int i = 0; i < context.P1.Points; i++)
            {
                context.WinCheckImageP1[i].SetActive(true);
                pointP1++;
            }
            for (int i = 0; i < context.P2.Points; i++)
            {
                context.WinCheckImageP2[i].SetActive(true);
                pointP2++;
            }

            if (pointP1 > pointP2)
            {
                context.SetPoint(pointP1);
            }
            else if (pointP2 > pointP1)
            {
                context.SetPoint(pointP2);
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
        }
    }
}