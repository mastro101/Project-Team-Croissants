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

        SetController setController;

        public override void Enter()
        {
            base.Enter();
            setController = null;
            SceneManager.LoadScene("B_CharacterSelect");
        }

        public override void Tick()
        {
            base.Tick();
            /*if (setController == null)
            {
                setController = FindObjectOfType<SetController>();
                setController.AssignedController = new System.Collections.Generic.List<int>();
                setController.NPlayer = 0;
            }*/
        }
    }
}