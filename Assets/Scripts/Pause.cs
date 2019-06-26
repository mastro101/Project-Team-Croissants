using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameplayState currentState;
    float normalTime;

    private void Awake()
    {
        normalTime = Time.timeScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            switch (currentState)
            {
                case GameplayState.Pause:
                    Time.timeScale = 0;
                    currentState = GameplayState.Play;
                    break;
                case GameplayState.Play:
                    Time.timeScale = normalTime;
                    currentState = GameplayState.Pause;
                    break;
                default:
                    break;
            }
        }
    }

    enum GameplayState
    {
        Pause,
        Play,
    }
}
