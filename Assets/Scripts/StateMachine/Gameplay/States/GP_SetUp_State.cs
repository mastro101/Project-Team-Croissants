﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

namespace StateMachine.Gameplay
{
    public class GP_SetUp_State : GP_Base_State
    {
        [SerializeField]
        GameObject tutorialPanel, GlowGO;

        GameObject tutorialInScene;

        protected override string stateName
        {
            get
            {
                return "SetUP";
            }
        }

        bool isSetup;
        GameObject[] glows = new GameObject[4];

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
                    player.Color = context.PlayersColor[n];
                    player.rigidbody.useGravity = false;
                    context.AbilityReady[n].transform.GetChild(0).GetComponent<Image>().sprite = player.AbilitySprite;
                    context.IconPlayer[n].sprite = player.IconCharacterSprite;
                    PlayerController playerC = player.gameObject.GetComponent<PlayerController>();
                    //playerC.dashTimerImage = context.DashTimerImage[n];
                    if (glows[n] != null)
                        Destroy(glows[n]);
                    glows[n] = Instantiate(GlowGO, player.transform.position + new Vector3(0, 0.13f, 0), GlowGO.transform.rotation, player.transform);
                    glows[n].GetComponent<SpriteRenderer>().color = player.Color;
                    if (player.DashVFX != null)
                    {
                        ParticleSystem.MainModule mainModule = player.DashVFX.main;
                        mainModule.startColor = player.Color;
                    }
                    playerC.abilityTimerImage = context.AbilityTimerImage[n];
                    playerC.abilityReady = context.AbilityReady[n];
                    playerC.abilityCDText = context.AbilityCDText[n];
                    n++;

                    player.Points = 0;
                }
            }

            context.FollowPlayerList.AddRange(context.Players);
            ListExtension.Shuffle(context.FollowPlayerList);

            for (int i = n; i < 4; i++)
            {
                context.AbilityReady[i].SetActive(false);
            }

            for (int i = n; i < 4; i++)
            {
                context.PlayerCheckWin[i].SetActive(false);
            }

            //context.P1.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P1;
            //context.P2.gameObject.GetComponent<PlayerController>().nPlayer = PlayerController.NPlayer.P2;
            
            context.EndRoundPanel.SetActive(false);
            //for (int i = 0; i < 3; i++)
            //{
                //context.WinCheckImageP1[i].SetActive(false);
                //context.WinCheckImageP2[i].SetActive(false);
                //context.WinPointImageP1[i].SetActive(false);
                //context.WinPointImageP2[i].SetActive(false);
            //}
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