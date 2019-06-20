using UnityEngine.SceneManagement;

namespace StateMachine.Menu
{
    public class Menu_SelectLevel_State : Menu_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "SelectLevel";
            }
        }

        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene("B_SceneSelector");
        }
    }
}