using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine.Gameplay
{
    public class GameplaySM : StateMachineBase
    {
        [SerializeField]
        List<PlayerBase> players;
        [SerializeField]
        List<EnemyBase> enemies;

        protected override void Start()
        {
            currentContext = new GameplaySMContext()
            {
                Players = players,
                Enemies = enemies,
            };
            base.Start();
        }

        private void Update()
        {
            
        }
    }

    public class GameplaySMContext : IStateMachineContext
    {
        public List<PlayerBase> Players;
        public List<EnemyBase> Enemies;
    }
}