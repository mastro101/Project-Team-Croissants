using UnityEngine;
using UnityEngine.SceneManagement;
using StateMachine.Menu;

public class ButtonSceneSelector : MonoBehaviour
{
    public string NomeScena;

    public void SelectScene()
    {
        FindObjectOfType<GameManager>().SelectedLevel = NomeScena;
        FindObjectOfType<MenuSM>().goNext();
        SceneManager.LoadScene("Ambientazione2");
    }
}
