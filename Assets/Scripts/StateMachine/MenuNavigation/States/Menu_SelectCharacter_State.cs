using UnityEngine.SceneManagement;

namespace StateMachine.Menu
{
    public class Menu_SelectCharacter_State : Menu_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "SelectCharacter";
            }
        }

        public override void Enter()
        {
            base.Enter();
            SceneManager.LoadScene("B_CharacterSelect");
        }
    }
}