using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateMachine.Menu
{
    public class MenuSM : StateMachineBase
    {
        [SerializeField] Animator luce;
        [SerializeField] GameObject startPanel, menuPanel;

        protected override void Start()
        {
            currentContext = new MenuSMContext()
            {
                GenericGoNext = goNext,
                Luce = luce,
                StartPanel = startPanel,
                MenuPanel = menuPanel,
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
    }

    public class MenuSMContext : IStateMachineContext
    {
        public Action GenericGoNext;
        public Animator Luce;
        public GameObject StartPanel, MenuPanel;
    }
}
