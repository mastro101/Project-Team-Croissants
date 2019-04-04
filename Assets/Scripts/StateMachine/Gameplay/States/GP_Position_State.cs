using UnityEngine;
using System.Collections;

namespace StateMachine.Gameplay
{
    public class GP_Position_State : GP_Base_State
    {
        //[SerializeField]
        //Animator animatorCountDown;
        [SerializeField]
        GameObject countdownPrefab, aimPrefab;

        protected override string stateName
        {
            get
            {
                return "Position";
            }
        }

        GameObject countdown, aim;
        public override void Enter()
        {
            //Destroy(aim);
            base.Enter();

            FindObjectOfType<AudioManager>().Play("Countdown");
            countdown = Instantiate(countdownPrefab, new Vector3(0, 25, -17), Quaternion.Euler(56, 0, 0), FindObjectOfType<Camera>().transform);
            //animatorCountDown.SetTrigger("Start");

            // Scambia i player e l'obbiettivo dell'Enemy
            IPlayer oldFollowedPlayer = context.FollowedPlayer;
            IPlayer oldRunnerPlayer = context.RunnerPlayer;
            context.FollowedPlayer = oldRunnerPlayer;
            context.RunnerPlayer = oldFollowedPlayer;
            //Rimove mirino
            if (context.Enemy.PlayerToFollow != null)
            context.Enemy.PlayerToFollow.Aim.SetActive(false);
            // Scelta random provvisoria
            context.Enemy.PlayerToFollow = context.Players[Random.Range(0, context.Players.Count)];
            //
            context.Enemy.PlayerToFollow.Aim.SetActive(true);
            context.FollowedPlayer.gameObject.GetComponent<PlayerController>().abilityReady.SetActive(true);
            context.RunnerPlayer.gameObject.GetComponent<PlayerController>().abilityReady.SetActive(true);
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