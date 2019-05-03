using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

namespace StateMachine.Gameplay
{
    public class GameplaySM : StateMachineBase
    {
        [SerializeField]
        Color[] playersColor;

        [SerializeField]
        EnemyBase enemy;
        [SerializeField]
        Transform enemyPosition;
        [SerializeField]
        GameObject canvas, endRoundPanel;
        [SerializeField]
        GameObject[] winCheckImageP1, winCheckImageP2, winCheckImageP3, winCheckImageP4, imageInseguito, playerCheckWin;
        [SerializeField]
        GameObject[] winPointImageP1, winPointImageP2;

        public Image[] dashTimerImage, abilityTimerImage;
        public GameObject[] abilityReady;
        public TextMeshProUGUI[] abilityCDText;
        public Image[] iconPlayer;

        public event GameplayStateEvent.EndState endBattle;
        public event GameplayStateEvent.StartState startBattle;


        protected override void Start()
        {
            currentContext = new GameplaySMContext()
            {
                GameManager = FindObjectOfType<GameManager>(),
                Enemy = enemy,
                Enemies = FindObjectsOfType<EnemyBase>(),
                EnemyTransform = enemyPosition,
                BaseExitState = goNext,
                EnemyStarterSpeed = enemy.MovementSpeed,
                Arena = FindObjectOfType<ArenaSplit>(),
                InvokeEndBattle = invokeEndBattle,
                InvockeStartBattle = invokeStartBattle,
                Canvas = canvas,
                WinCheckImageP1 = new GameObject[]
                {
                    winCheckImageP1[0], winCheckImageP1[1], winCheckImageP1[2], winCheckImageP1[3]
                },
                WinCheckImageP2 = new GameObject[]
                {
                    winCheckImageP2[0], winCheckImageP2[1], winCheckImageP2[2], winCheckImageP2[3]
                },
                WinCheckImageP3 = new GameObject[]
                {
                    winCheckImageP3[0], winCheckImageP3[1], winCheckImageP3[2], winCheckImageP3[3]
                },
                WinCheckImageP4 = new GameObject[]
                {
                    winCheckImageP4[0], winCheckImageP4[1], winCheckImageP4[2], winCheckImageP4[3],
                },
                ImageInseguito = new GameObject[]
                {
                    imageInseguito[0], imageInseguito[1], imageInseguito[2], imageInseguito[3]
                },
                PlayerCheckWin = new GameObject[]
                {
                    playerCheckWin[0], playerCheckWin[1], playerCheckWin[2], playerCheckWin[3]
                },
                //WinPointImageP1 = new GameObject[]
                //{
                //    winPointImageP1[0], winPointImageP1[1], winPointImageP1[2]
                //},
                //WinPointImageP2 = new GameObject[]
                //{
                //    winPointImageP2[0], winPointImageP2[1], winPointImageP2[2]
                //},
                EndRoundPanel = endRoundPanel,
                SetPoint = setPoint,
                DashTimerImage = dashTimerImage,
                AbilityTimerImage = abilityTimerImage,
                AbilityReady = abilityReady,
                AbilityCDText = abilityCDText,
                IconPlayer = iconPlayer,
                PlayersColor = playersColor,
                FollowPlayerList = new List<IPlayer>(),
            };
            base.Start();
        }

        void goNext()
        {
            SM.SetTrigger("Exit");
        }

        void setPoint(int _point)
        {
            SM.SetInteger("Point", _point);
        }

        void invokeEndBattle()
        {
            if (endBattle != null)
            {
                endBattle();
            }
        }

        void invokeStartBattle()
        {
            if (startBattle != null)
            {
                startBattle();
            }
        }
    }

    public class GameplaySMContext : IStateMachineContext
    {
        public GameManager GameManager;
        public IEnemy Enemy;
        public IEnemy[] Enemies;
        public List<IPlayer> Players;
        public IPlayer FollowedPlayer;
        public Transform RunnerPlayerTransform, FollowedPlayerTransform, EnemyTransform;
        /// <summary>
        /// Delegato chiamato per uscire da uno stato con una sola uscita o con un'uscita di default
        /// </summary>
        public Action BaseExitState;
        public float EnemyStarterSpeed;
        public ArenaSplit Arena;
        public Action InvokeEndBattle;
        public Action InvockeStartBattle;
        public Action<int> SetPoint;
        public GameObject Canvas, EndRoundPanel;
        public GameObject[] WinCheckImageP1, WinCheckImageP2, WinCheckImageP3, WinCheckImageP4, ImageInseguito, PlayerCheckWin;
        public GameObject[] WinPointImageP1, WinPointImageP2;

        public Image[] DashTimerImage, AbilityTimerImage;
        public GameObject[] AbilityReady;
        public TextMeshProUGUI[] AbilityCDText;

        public Image[] IconPlayer;
        public Color[] PlayersColor;
        public List<IPlayer> FollowPlayerList;
    }

    public class GameplayStateEvent
    {
        public delegate void EndState();
        public delegate void StartState();
    }
}