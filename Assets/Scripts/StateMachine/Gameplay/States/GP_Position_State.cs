using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        SpawnPoint spawnPoint;
        GameObject countdown, aim;
        public override void Enter()
        {
            //Destroy(aim);
            base.Enter();
            spawnPoint = FindObjectOfType<SpawnPoint>();
            FindObjectOfType<AudioManager>().Play("Countdown");
            countdown = Instantiate(countdownPrefab, new Vector3(0, 25, -17), Quaternion.Euler(56, 0, 0), FindObjectOfType<Camera>().transform);
            //animatorCountDown.SetTrigger("Start");

            foreach (GameObject image in context.ImageInseguito)
            {
                image.SetActive(false);
            }

            //Rimuove mirino

            if (context.Enemy.PlayerToFollow != null)
                context.Enemy.PlayerToFollow.Aim.SetActive(false);
            // Cambio PlayerToFollow
            int nPlayer = 0;
            if (context.FollowPlayerList.Count == 0)
            {
                nPlayer = Random.Range(0, context.Players.Count);
                context.FollowPlayerList.Add(context.Players[nPlayer]);
                context.Enemy.PlayerToFollow = context.Players[nPlayer];
            }
            else if (context.FollowPlayerList.Count < context.Players.Count)
            {
                nPlayer = Random.Range(0, context.Players.Count);
                foreach (IPlayer p in context.FollowPlayerList)
                {
                    if (context.Players[nPlayer] != p)
                    {
                        context.FollowPlayerList.Add(context.Players[nPlayer]);
                        context.Enemy.PlayerToFollow = context.Players[nPlayer];
                    }
                }
            }

            //

            int n = 0;
            foreach (IPlayer player in context.Players)
            {
                if (player != null)
                {
                    player.rigidbody.useGravity = false;
                    player.rigidbody.velocity = Vector3.zero;
                    player.gameObject.GetComponent<PlayerController>().abilityReady.SetActive(true);
                    if (nPlayer == n)
                    {
                        context.ImageInseguito[n].SetActive(true);
                    }
                }
                n++;
            }

            context.Enemy.PlayerToFollow.Aim.SetActive(true);

            // Riposiziona i player nei loro punti iniziali
            int i = 0;
            foreach (IPlayer player in context.Players)
            {
                player.gameObject.SetActive(true);
                if (spawnPoint != null)
                {
                    if (player != null)
                        player.gameObject.transform.position = spawnPoint.PlayerSpawn[i].position + (Vector3.up * 1.5f);

                    i++;
                }
                player.IsGameOver = false;
            }

            if (context.EnemyTransform != null)
                context.Enemy.transform.position = context.EnemyTransform.position;
            // Resetta variabili
            context.Enemy.MovementSpeed = context.EnemyStarterSpeed;
            context.Enemy.transform.localScale = Vector3.one; 
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