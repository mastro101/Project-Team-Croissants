﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

        bool isSetup;

        public override void Enter()
        {
            base.Enter();
            tutorialInScene = Instantiate(tutorialPanel, context.Canvas.transform);
            tutorialInScene.SetActive(true);
            int n = 0;
            foreach (IPlayer player in context.Players)
            {
                if (player != null)
                {
                    context.AbilityReady[n].transform.GetChild(0).GetComponent<Image>().sprite = player.AbilitySprite;
                    context.IconPlayer[n].sprite = player.IconCharacterSprite;
                    PlayerController playerC = player.gameObject.GetComponent<PlayerController>();
                    // playerC.dashTimerImage = context.DashTimerImage[n];
                    playerC.abilityTimerImage = context.AbilityTimerImage[n];
                    playerC.abilityReady = context.AbilityReady[n];
                    playerC.abilityCDText = context.AbilityCDText[n];
                    n++;

                    player.Points = 0;
                }
            }

            //context.P1.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P1;
            //context.P2.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P2;
            
            context.EndRoundPanel.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                //context.WinCheckImageP1[i].SetActive(false);
                //context.WinCheckImageP2[i].SetActive(false);
                //context.WinPointImageP1[i].SetActive(false);
                //context.WinPointImageP2[i].SetActive(false);
            }
            isSetup = true;

            //context.P1.gameObject.GetComponent<PlayerController>().dashTimerImage.fillAmount = 1;
            //context.P1.gameObject.GetComponent<PlayerController>().abilityTimerImage.fillAmount = 1;
            //context.P2.gameObject.GetComponent<PlayerController>().dashTimerImage.fillAmount = 1;
            //context.P2.gameObject.GetComponent<PlayerController>().abilityTimerImage.fillAmount = 1;
        }

        public override void Tick()
        {
            base.Tick();
            if (Input.anyKeyDown)
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