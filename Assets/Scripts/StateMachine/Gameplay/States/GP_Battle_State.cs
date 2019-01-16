using UnityEngine;
using System.Collections;

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

        PlayerController followedPlayerController, runnerPlayerController;

        public override void Enter()
        {
            base.Enter();
            context.Enemy.PlayerToFollow = context.FollowedPlayer;
            foreach (IEnemy enemy in context.Enemies)
            {
                Debug.Log(enemy.gameObject.name);
                enemy.HitPlayer += AddPoint;
            }
            if (context.FollowedPlayer != null)
                followedPlayerController = context.FollowedPlayer.gameObject.GetComponent<PlayerController>();
            if (context.RunnerPlayer != null)
                runnerPlayerController = context.RunnerPlayer.gameObject.GetComponent<PlayerController>();
            if (context.Arena != null)
                context.Arena.StartCoroutine(context.Arena.MoveRL());
        }

        public override void Tick()
        {
            base.Tick();
            context.Enemy.Movement();
            if (followedPlayerController != null)
                followedPlayerController.PlayerInput();
            if (runnerPlayerController != null)
                runnerPlayerController.PlayerInput();
        }

        public override void Exit()
        {
            base.Exit();
            foreach (IEnemy enemy in context.Enemies)
            {
                enemy.HitPlayer -= AddPoint;
            }
            context.InvokeEndBattle();
        }

        void AddPoint(IPlayer player)
        {
            Debug.Log("AddPoint");
            context.FollowedPlayer.SM.SetTrigger("GameOver");
            context.RunnerPlayer.SM.SetTrigger("GameOver");

            if (player == context.FollowedPlayer)
            {
                context.RunnerPlayer.AddPoint(1);
            }

            if (player == context.RunnerPlayer)
            {
                context.FollowedPlayer.AddPoint(1);
            }

            // Esci dallo stato
            context.BaseExitState();
        }
    }
}