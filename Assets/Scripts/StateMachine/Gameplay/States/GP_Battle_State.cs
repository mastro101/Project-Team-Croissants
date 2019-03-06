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

        PlayerController followedPlayerController, runnerPlayerController;

        public override void Enter()
        {
            base.Enter();
            context.InvockeStartBattle();

            context.Enemy.PlayerToFollow = context.FollowedPlayer;
            context.Enemy.SM.SetTrigger("Movement");
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
            if (followedPlayerController != null)
                followedPlayerController.PlayerInput();
            if (runnerPlayerController != null)
                runnerPlayerController.PlayerInput();
        }

        public override void Exit()
        {
            base.Exit();
            //DOTween.PauseAll();
            context.Enemy.SM.SetTrigger("Idle");
            context.Enemy.transform.localScale = Vector3.one;
            context.FollowedPlayer.SM.SetBool("Run", false);
            context.RunnerPlayer.SM.SetBool("Run", false);
            context.FollowedPlayerTransform.rotation = Quaternion.Euler(Vector3.zero);
            context.RunnerPlayerTransform.rotation = Quaternion.Euler(Vector3.zero);
            foreach (IEnemy enemy in context.Enemies)
            {
                enemy.HitPlayer -= AddPoint;
            }
            context.InvokeEndBattle();
        }

        void AddPoint(IPlayer player)
        {
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