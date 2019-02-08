﻿using UnityEngine;
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

        bool isSetup;

        public override void Enter()
        {
            base.Enter();
            context.P1.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P1;
            context.P2.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P2;
            tutorialInScene = Instantiate(tutorialPanel, context.Canvas.transform);
            tutorialInScene.SetActive(true);
            context.EndRoundPanel.SetActive(false);
            context.P1.Points = 0;
            context.P2.Points = 0;
            for (int i = 0; i < 3; i++)
            {
                context.WinCheckImageP1[i].SetActive(false);
                context.WinCheckImageP2[i].SetActive(false);
            }
            isSetup = true;
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