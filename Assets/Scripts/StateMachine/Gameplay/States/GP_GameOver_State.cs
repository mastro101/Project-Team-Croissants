using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace StateMachine.Gameplay
{
    public class GP_GameOver_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "GameOver";
            }
        }

        public override void Enter()
        {
            base.Enter();
            context.EndRoundPanel.SetActive(true);

        }

        public override void Tick()
        {
            base.Tick();
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                //SceneManager.LoadScene("CharacterSelect");
                context.BaseExitState();
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
        }
    }
}