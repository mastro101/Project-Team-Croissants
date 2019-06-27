using UnityEngine;
using StateMachine.Menu;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<MenuSM>().goNext(0);
    }

    public void PlayTutorial()
    {
        FindObjectOfType<MenuSM>().goNext(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
