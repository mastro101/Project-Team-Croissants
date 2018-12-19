using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_Position_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Position";
            }
        }

        public override void Enter()
        {
            base.Enter();
            // Scambia i player e l'obbiettivo dell'Enemy
            IPlayer oldFollowedPlayer = context.FollowedPlayer;
            IPlayer oldRunnerPlayer = context.RunnerPlayer;
            context.FollowedPlayer = oldRunnerPlayer;
            context.RunnerPlayer = oldFollowedPlayer;
            context.Enemy.PlayerToFollow = context.FollowedPlayer;
            // Riposiziona i player nei loro punti iniziali
            if (context.FollowedPlayerTransform != null)
                context.FollowedPlayer.transform.position = context.FollowedPlayerTransform.position;
            if (context.RunnerPlayerTransform != null)
                context.RunnerPlayer.transform.position = context.RunnerPlayerTransform.position;
            if (context.EnemyTransform != null)
                context.Enemy.transform.position = context.EnemyTransform.position;
            //Esci dallo stato
            context.BaseExitState();
        }
    }
}