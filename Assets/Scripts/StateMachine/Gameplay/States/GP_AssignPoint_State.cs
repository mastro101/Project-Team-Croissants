using DG.Tweening;
using UnityEngine;

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
            foreach (IPlayer p in context.Players)
            {
                p.gameObject.SetActive(true);
            }
            FindObjectOfType<AudioManager>().Play("EndRound");
            base.Enter();
            pointP1 = 0;
            pointP2 = 0;
            pointP3 = 0;
            pointP4 = 0;
            context.EndRoundPanel.SetActive(true);
            for (int i = 0; i < context.Players[0].Points; i++)
            {
                if (!context.WinCheckImageP1[i].activeInHierarchy)
                {
                    context.WinCheckImageP1[i].SetActive(true);
                    context.WinCheckImageP1[i].GetComponent<Animator>().SetTrigger("Next");
                }
                //context.WinPointImageP1[i].SetActive(true);
                context.WinCheckImageP1[i].transform.DOScale(1, 1).SetEase(Ease.OutBack);
                pointP1++;
            }
            if (context.Players.Count > 1)
                for (int i = 0; i < context.Players[1].Points; i++)
                {
                    if (!context.WinCheckImageP2[i].activeInHierarchy)
                    {
                        context.WinCheckImageP2[i].SetActive(true);
                        context.WinCheckImageP2[i].GetComponent<Animator>().SetTrigger("Next");
                    }
                    // context.WinPointImageP2[i].SetActive(true);
                    context.WinCheckImageP2[i].transform.DOScale(1, 1).SetEase(Ease.OutBack);
                    pointP2++;
                }
            if (context.Players.Count > 2)
            {
                for (int i = 0; i < context.Players[2].Points; i++)
                {
                    if (!context.WinCheckImageP3[i].activeInHierarchy)
                    {
                        context.WinCheckImageP3[i].SetActive(true);
                        context.WinCheckImageP3[i].GetComponent<Animator>().SetTrigger("Next");
                    }
                    context.WinCheckImageP3[i].transform.DOScale(1, 1).SetEase(Ease.OutBack);
                    pointP3++;
                }
            }
            if (context.Players.Count > 3)
            {
                for (int i = 0; i < context.Players[3].Points; i++)
                {
                    if (!context.WinCheckImageP4[i].activeInHierarchy)
                    {
                        context.WinCheckImageP4[i].SetActive(true);
                        context.WinCheckImageP4[i].GetComponent<Animator>().SetTrigger("Next");
                    }
                    context.WinCheckImageP4[i].transform.DOScale(1, 1).SetEase(Ease.OutBack);
                    pointP4++;
                }
            }

            if (pointP1 >= 4 || pointP2 >= 4 || pointP3 >= 4 || pointP4 >= 4)
            {
                context.SetPoint(4);
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
            context.SetPoint(0);
        }
    }
}