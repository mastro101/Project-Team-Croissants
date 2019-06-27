using UnityEngine.SceneManagement;

namespace StateMachine.Menu
{
    public class Menu_Tutorial_State : Menu_Base_State
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
            FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
            FindObjectOfType<GameManager>().SelectedLevel = "B_DeNittisOrigins_HorizontalSplit_Tutorial";

            context.GenericGoNext();
            SceneManager.LoadScene("Ambientazione2Tutorial");
        }
    }
}