using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace StateMachine.Gameplay
{
    public class GP_Battle_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Battle";
            }
        }

        PlayerController followedPlayerController;
        PlayerController[] PlayersController = new PlayerController[4];
        int NPlayerInGameOver;

        public override void Enter()
        {
            base.Enter();
            context.InvockeStartBattle();
            NPlayerInGameOver = 0;

            //context.Enemy.PlayerToFollow = context.FollowedPlayer;
            context.Enemy.SM.SetTrigger("Movement");
            foreach (IEnemy enemy in context.Enemies)
            {
                Debug.Log(enemy.gameObject.name);
                enemy.HitPlayer += CheckGameOver;
            }
            if (context.FollowedPlayer != null)
                followedPlayerController = context.FollowedPlayer.gameObject.GetComponent<PlayerController>();
            if (context.Arena != null)
                context.Arena.StartCoroutine(context.Arena.MoveRL());

            for (int i = 0; i < context.Players.Count; i++)
            {
                if (context.Players[i] != null)
                {
                    PlayersController[i] = context.Players[i].gameObject.GetComponent<PlayerController>();
                }
            }

            foreach (IPlayer player in context.Players)
            {
                player.rigidbody.useGravity = true;
            }
        }

        public override void Tick()
        {
            base.Tick();
            foreach (PlayerController player in PlayersController)
            {
                if (player != null && !player.gameObject.GetComponent<IPlayer>().IsGameOver)
                    player.PlayerInput();
            }
        }

        public override void Exit()
        {
            base.Exit();
            //DOTween.PauseAll();
            context.Enemy.SM.SetTrigger("Idle");
            context.Enemy.transform.localScale = Vector3.one;
            foreach (IPlayer player in context.Players)
            {
                if (player != null)
                {
                    player.SM.SetBool("Run", false);
                    player.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
            foreach (IEnemy enemy in context.Enemies)
            {
                enemy.HitPlayer -= CheckGameOver;
            }
            context.InvokeEndBattle();
        }

        void CheckGameOver(IPlayer player)
        {
            player.IsGameOver = true;
            foreach (IPlayer p in context.Players)
            {
                if (p != null && p.IsGameOver)
                {
                    NPlayerInGameOver++;
                }
            }

            if (NPlayerInGameOver >= context.Players.Count - 1)
            {
                foreach (IPlayer p in context.Players)
                {
                    if (p != null && !p.IsGameOver)
                    {
                        p.AddPoint(1);
                        context.BaseExitState();
                    }
                }
            }
            else
            { 
                foreach (IPlayer p in context.Players)
                {
                    if (p != null)
                    {
                        if (!p.IsGameOver)
                        context.Enemy.PlayerToFollow = p;
                    }
                }
            }
        }
    }
}