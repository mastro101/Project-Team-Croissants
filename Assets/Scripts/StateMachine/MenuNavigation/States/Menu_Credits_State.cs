using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Menu
{

    public class Menu_Credits_State : Menu_Base_State
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
            FindObjectOfType<AudioManager>().Pause();
            FindObjectOfType<AudioManager>().Play("SottofondoMenu");
            SceneManager.LoadScene("Credits");
        }

        public override void Tick()
        {
            base.Tick();
            if (Input.anyKeyDown)
            {
                context.GenericGoNext();
            }
        }
    }
}