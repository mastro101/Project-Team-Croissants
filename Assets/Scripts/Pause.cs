using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachine.Menu;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    GameplayState currentState;
    float normalTime;

    private void Awake()
    {
        normalTime = Time.timeScale;
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            FindObjectOfType<AudioManager>().Play("OpenPauseMenu");
            switch (currentState)
            {
                case GameplayState.Pause:
                    Time.timeScale = 0;
                    currentState = GameplayState.Play;
                    pauseMenu.SetActive(true);
                    break;
                case GameplayState.Play:
                    Time.timeScale = normalTime;
                    currentState = GameplayState.Pause;
                    pauseMenu.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("ClosePauseMenu");
        currentState = GameplayState.Play;
        pauseMenu.SetActive(false);
        Time.timeScale = normalTime;
    }

    public void Restart()
    {
        Time.timeScale = normalTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        FindObjectOfType<MenuSM>().goNext(0);
    }

    enum GameplayState
    {
        Pause,
        Play,
    }
}
