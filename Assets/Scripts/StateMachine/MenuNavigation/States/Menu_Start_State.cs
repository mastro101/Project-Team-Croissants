using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.Menu
{

    public class Menu_Start_State : Menu_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "Menu Start";
            }
        }

        public override void Enter()
        {
            base.Enter();
         //   FindObjectOfType<AudioManager>().Pause();
         //   FindObjectOfType<AudioManager>().Play("SottofondoMenu");
            context.LuceAnimator = context.LuceGO.GetComponent<Animator>();
        }

        public override void Tick()
        {
            base.Tick();
            if (Input.anyKeyDown)
            {
                FindObjectOfType<AudioManager>().Play("PressAnyButtonSound");
                context.GenericGoNext();
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.LuceAnimator.SetTrigger("Exit");
        }
    }
}