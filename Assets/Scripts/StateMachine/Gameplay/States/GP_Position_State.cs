using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_Position_State : GP_Base_State
    {
        //[SerializeField]
        //Animator animatorCountDown;
        [SerializeField]
        GameObject countdownPrefab;

        protected override string stateName
        {
            get
            {
                return "Position";
            }
        }

        GameObject countdown;
        public override void Enter()
        {
            base.Enter();
            FindObjectOfType<AudioManager>().Play("Countdown");
            countdown = Instantiate(countdownPrefab, new Vector3(0, 25, -17), Quaternion.Euler(56, 0, 0), FindObjectOfType<Camera>().transform);
            //animatorCountDown.SetTrigger("Start");

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
            // Resetta variabili
            context.Enemy.MovementSpeed = context.EnemyStarterSpeed;
            // Resetta Arena
            if (context.Arena != null)
                context.Arena.Setup();
            //Esci dallo stato
            context.BaseExitState();
        }

        public override void Exit()
        {
            base.Exit();
            Destroy(countdown);
        }
    }
}