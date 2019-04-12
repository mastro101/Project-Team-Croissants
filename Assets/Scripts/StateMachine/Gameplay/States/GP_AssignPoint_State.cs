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

        int pointP1, pointP2, pointP3, pointP4;

        public override void Enter()
        {
            FindObjectOfType<AudioManager>().Play("EndRound");
            base.Enter();
            pointP1 = 0;
            pointP2 = 0;
            pointP3 = 0;
            pointP4 = 0;
            context.EndRoundPanel.SetActive(true);
            for (int i = 0; i < context.Players[0].Points; i++)
            {
                context.WinCheckImageP1[i].SetActive(true);
                //context.WinPointImageP1[i].SetActive(true);
                pointP1++;
            }
            for (int i = 0; i < context.Players[1].Points; i++)
            {
                context.WinCheckImageP2[i].SetActive(true);
               // context.WinPointImageP2[i].SetActive(true);
                pointP2++;
            }
            if (context.Players.Count > 1)
            {
                for (int i = 0; i < context.Players[2].Points; i++)
                {
                    context.WinCheckImageP3[i].SetActive(true);
                    pointP3++;
                }
            }
            if (context.Players.Count > 2)
            {
                for (int i = 0; i < context.Players[3].Points; i++)
                {
                    context.WinCheckImageP4[i].SetActive(true);
                    pointP4++;
                }
            }
            if (context.Players.Count >= 3)
            {
                if (pointP1 >= 4 || pointP2 >= 4 || pointP3 >= 4 || pointP4 >= 4)
                {
                    context.SetPoint(4);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
        }
    }
}