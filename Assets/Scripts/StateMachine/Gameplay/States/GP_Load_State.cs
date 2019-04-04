﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Gameplay
{
    public class GP_Load_State : GP_Base_State
    {
        protected override string stateName { get { return "Load"; } }

        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadSceneAsync(context.GameManager.SelectedLevel, LoadSceneMode.Additive);
            context.Players = new List<IPlayer>();
            foreach (GameObject player in context.GameManager.PlayersGO)
            {
                if (player != null)
                {
                    GameObject p = Instantiate(player, Vector3.up * 1.5f, Quaternion.Euler(Vector3.zero));
                    context.Players.Add(p.GetComponent<IPlayer>());
                }
            }
        }
    }
}