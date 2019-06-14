using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

namespace StateMachine.Gameplay
{
    public class GP_NewGameOver_State : GP_Base_State
    {
        protected override string stateName
        {
            get
            {
                return "GameOver";
            }
        }

        [SerializeField] GameObject[] WinAnimationPerColorPrefab;

        GameObject currentWinAnimationPerColor, currentWinAnimationPerPlayer;
        public override void Enter()
        {
            base.Enter();
            FindObjectOfType<AudioManager>().Play("EndGame");
            int i = 0;
            foreach (IPlayer player in context.Players)
            {
                if (player.Points == 4)
                {
                    currentWinAnimationPerColor = Instantiate(WinAnimationPerColorPrefab[i], context.Canvas.transform);
                    if (player.VictoryAnimation != null)
                    {
                        currentWinAnimationPerPlayer = Instantiate(player.VictoryAnimation, context.Canvas.transform);
                    }
                }
                i++;
            }
        }

        public override void Tick()
        {
            base.Tick();
            if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space))
            {
                //SceneManager.LoadScene("CharacterSelect");
                context.BaseExitState();
            }
        }

        public override void Exit()
        {
            base.Exit();
            Destroy(currentWinAnimationPerColor);
            if (currentWinAnimationPerPlayer != null)
                Destroy(currentWinAnimationPerPlayer);
        }
    }
}