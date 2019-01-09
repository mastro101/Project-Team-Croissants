using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace StateMachine.Gameplay
{
    public class GameplaySM : StateMachineBase
    {
        [SerializeField]
        PlayerBase runnerPlayer, followedPlayer;
        [SerializeField]
        EnemyBase enemy;
        [SerializeField]
        Transform runnerPosition, followedPosition, enemyPosition;

        protected override void Start()
        {
            currentContext = new GameplaySMContext()
            {
                Enemy = enemy,
                Enemies = FindObjectsOfType<EnemyBase>(),
                FollowedPlayer = followedPlayer,
                RunnerPlayer = runnerPlayer,
                RunnerPlayerTransform = runnerPosition,
                FollowedPlayerTransform = followedPosition,
                EnemyTransform = enemyPosition,
                BaseExitState = goNext,
                EnemyStarterSpeed = enemy.MovementSpeed,
                Arena = FindObjectOfType<ArenaSplit>(),
            };
            base.Start();
        }

        void goNext()
        {
            SM.SetTrigger("Exit");
        }
    }

    public class GameplaySMContext : IStateMachineContext
    {
        public IEnemy Enemy;
        public IEnemy[] Enemies;
        public IPlayer FollowedPlayer , RunnerPlayer;
        public Transform RunnerPlayerTransform, FollowedPlayerTransform, EnemyTransform;
        /// <summary>
        /// Delegato chiamato per uscire da uno stato con una sola uscita o con un'uscita di default
        /// </summary>
        public Action BaseExitState;
        public float EnemyStarterSpeed;
        public ArenaSplit Arena;
    }
}