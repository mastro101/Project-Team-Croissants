using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Gameplay
{
    public class GP_Load_State : GP_Base_State
    {
        protected override string stateName { get { return "Load"; } }

        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadSceneAsync(context.GameManager.SelectedLevel, LoadSceneMode.Additive);
        }
    }
}