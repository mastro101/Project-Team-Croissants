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
                FollowedPlayer = followedPlayer,
                RunnerPlayer = runnerPlayer,
                RunnerPlayerPosition = runnerPosition,
                FollowedPlayerTransform = followedPosition,
                EnemyPosition = enemyPosition,
                BaseExitState = goNext,
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
        public IPlayer FollowedPlayer , RunnerPlayer;
        public Transform RunnerPlayerPosition, FollowedPlayerTransform, EnemyPosition;
        /// <summary>
        /// Delegato chiamato per uscire da uno stato con una sola uscita o con un'uscita di default
        /// </summary>
        public Action BaseExitState;
    }
}