using UnityEngine;
using System.Collections;

namespace StateMachine.Menu
{
    public class Menu_Gameplay_State : Menu_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Gameplay";
            }
        }

        public override void Enter()
        {
            base.Enter();
            FindObjectOfType<AudioManager>().Pause();
            FindObjectOfType<AudioManager>().Play("SottofondoArena");
        }
    }
}