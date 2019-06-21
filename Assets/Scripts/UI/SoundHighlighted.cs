using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundHighlighted : MonoBehaviour, ISelectHandler, ISubmitHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuScrolling");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
    }
}
