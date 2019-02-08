using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

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

        [SerializeField]
        GameObject pressToGO, winGO;

        TextMeshProUGUI winText;
        GameObject tempPressTo, tempWin;

        public override void Enter()
        {
            base.Enter();
            winText = winGO.GetComponent<TextMeshProUGUI>();
            FindObjectOfType<AudioManager>().Play("EndGame");
            context.EndRoundPanel.SetActive(true);
            if (context.P1.Points == 3)
            {
                winText.text = "BARONE WINS THE MATCH";
            }
            else
            {
                winText.text = "VEEKY WINS THE MATCH";
            }
            tempPressTo = Instantiate(pressToGO, context.Canvas.transform);
            tempWin = Instantiate(winGO, context.Canvas.transform);

        }

        public override void Tick()
        {
            base.Tick();
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene("CharacterSelect");
                context.BaseExitState();
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("CharacterSelect");
                context.BaseExitState();
            }
        }

        public override void Exit()
        {
            base.Exit();
            context.EndRoundPanel.SetActive(false);
            Destroy(tempPressTo);
            Destroy(tempWin);
        }
    }
}