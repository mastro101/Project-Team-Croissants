using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.Gameplay
{
    public class GP_Load_State : GP_Base_State
    {
        protected override string stateName { get { return "Load"; } }

        [SerializeField]
        GameObject tutorialPanel;

        GameObject tutorialInScene;

        public override void Enter()
        {
            base.Enter();
            tutorialInScene = Instantiate(tutorialPanel, context.Canvas.transform);
            tutorialInScene.SetActive(true);

            SceneManager.LoadSceneAsync(context.GameManager.SelectedLevel, LoadSceneMode.Additive);
            context.Players = new List<IPlayer>();

            int n = 0;
            foreach (GameObject player in context.GameManager.PlayersGO)
            {
                if (player != null)
                {
                    GameObject p = Instantiate(player, Vector3.up * (n + 2f), Quaternion.Euler(Vector3.zero));
                    p.GetComponent<PlayerController>().SetController(n);
                    context.Players.Add(p.GetComponent<IPlayer>());
                    n++;
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
            Destroy(tutorialInScene);
        }

    }
}