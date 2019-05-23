using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Menu
{

    public class Menu_Menu_State : Menu_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Menu";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.StartPanel.SetActive(false);
            context.MenuPanel.SetActive(true);
        }
    }
}