using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace StateMachine.Gameplay
{
    public class GameplaySM : StateMachineBase
    {
        [SerializeField]
        PlayerBase p1, p2;
        [SerializeField]
        EnemyBase enemy;
        [SerializeField]
        Transform runnerPosition, followedPosition, enemyPosition;
        [SerializeField]
        GameObject canvas, endRoundPanel;
        [SerializeField]
        GameObject[] winCheckImageP1, winCheckImageP2;

        public event GamplayStateEvent.EndState endBattle;


        protected override void Start()
        {
            currentContext = new GameplaySMContext()
            {
                Enemy = enemy,
                Enemies = FindObjectsOfType<EnemyBase>(),
                P1 = p1,
                P2 = p2,
                FollowedPlayer = p1,
                RunnerPlayer = p2,
                RunnerPlayerTransform = runnerPosition,
                FollowedPlayerTransform = followedPosition,
                EnemyTransform = enemyPosition,
                BaseExitState = goNext,
                EnemyStarterSpeed = enemy.MovementSpeed,
                Arena = FindObjectOfType<ArenaSplit>(),
                InvokeEndBattle = invokeEndBattle,
                Canvas = canvas,
                WinCheckImageP1 = new GameObject[]
                {
                    winCheckImageP1[0], winCheckImageP1[1], winCheckImageP1[2]
                },
                WinCheckImageP2 = new GameObject[]
                {
                    winCheckImageP2[0], winCheckImageP2[1], winCheckImageP2[2]
                },
                EndRoundPanel = endRoundPanel,
            };
            base.Start();
        }

        void goNext()
        {
            SM.SetTrigger("Exit");
        }

        void invokeEndBattle()
        {
            if (endBattle != null)
            {
                endBattle();
            }
        }
    }

    public class GameplaySMContext : IStateMachineContext
    {
        public IEnemy Enemy;
        public IEnemy[] Enemies;
        public IPlayer P1, P2, FollowedPlayer, RunnerPlayer;
        public Transform RunnerPlayerTransform, FollowedPlayerTransform, EnemyTransform;
        /// <summary>
        /// Delegato chiamato per uscire da uno stato con una sola uscita o con un'uscita di default
        /// </summary>
        public Action BaseExitState;
        public float EnemyStarterSpeed;
        public ArenaSplit Arena;
        public Action InvokeEndBattle;
        public GameObject Canvas, EndRoundPanel;
        public GameObject[] WinCheckImageP1, WinCheckImageP2;
    }

    public class GamplayStateEvent
    {
        public delegate void EndState();
    }
}