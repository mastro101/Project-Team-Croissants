using UnityEngine;
using UnityEngine.SceneManagement;

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
            FindObjectOfType<AudioManager>().Pause();
            FindObjectOfType<AudioManager>().Play("SottofondoMenu");
            if (SceneManager.GetActiveScene().name != "StartScene")
                SceneManager.LoadScene("MenuScene");
            context.canvasInGame = FindObjectOfType<Canvas>().gameObject;
            if (context.canvasInGame == null)
            {
                GameObject canvas = Instantiate(context.CanvasPrefab);
                context.canvasInGame = canvas;
            }
            if (context.StartPanel != null)
                Destroy(context.StartPanel);
            context.MenuPanelInGame = Instantiate(context.MenuPanelPrefab, context.canvasInGame.transform);
            context.MenuPanelPrefab.SetActive(true);
        }
    }
}