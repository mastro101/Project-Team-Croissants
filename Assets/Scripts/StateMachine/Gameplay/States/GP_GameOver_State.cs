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
            //FindObjectOfType<AudioManager>().Play("EndGame");
            context.EndRoundPanel.SetActive(true);
            foreach (IPlayer player in context.Players)
            {
                if (player.Points == 4)
                {
                    winText.text = player.Name + " Wins the match";
                    break;
                }
            }
            tempPressTo = Instantiate(pressToGO, context.Canvas.transform);
            tempWin = Instantiate(winGO, context.Canvas.transform);
            tempWin.GetComponent<TextMeshProUGUI>().text = winText.text;
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
                SceneManager.LoadScene("B_CharacterSelect");
                context.BaseExitState();
            }
        }

        public override void Exit()
        {
            base.Exit();

            context.FollowPlayerList = new System.Collections.Generic.List<IPlayer>();
            foreach (IPlayer player in context.Players)
            {
                player.Points = 0;
            }

            for (int i = 0; i < 4; i++)
            {
                context.WinCheckImageP1[i].SetActive(false);
                context.WinCheckImageP2[i].SetActive(false);
                context.WinCheckImageP3[i].SetActive(false);
                context.WinCheckImageP4[i].SetActive(false);

            }

            context.EndRoundPanel.SetActive(false);
            Destroy(tempPressTo);
            Destroy(tempWin);
        }
    }
}