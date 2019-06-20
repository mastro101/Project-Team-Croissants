using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Menu
{
    public class MenuSM : StateMachineBase
    {
        [SerializeField] GameObject canvasPrefab, luce, startPanel, menuPanelPrefab;

        protected override void Start()
        {
            currentContext = new MenuSMContext()
            {
                GenericGoNext = goNext,
                GoNext = goNext,
                LuceGO = luce,
                StartPanel = startPanel,
                MenuPanelPrefab = menuPanelPrefab,
                CanvasPrefab = canvasPrefab,
            };
            base.Start();
        }

        public void goNext()
        {
            SM.SetTrigger("Exit");
        }

        public void goBack()
        {
            SM.SetTrigger("Back");
        }

        public void goNext(int path)
        {
            SM.SetInteger("Path", path);
        }
    }

    public class MenuSMContext : IStateMachineContext
    {
        public Action GenericGoNext;
        public Action<int> GoNext;
        public GameObject CanvasPrefab;
        public Animator LuceAnimator;
        public GameObject LuceGO, StartPanel, MenuPanelPrefab, MenuPanelInGame, canvasInGame;
    }
}
