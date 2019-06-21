using UnityEngine;
using UnityEngine.EventSystems;

public class UISound : MonoBehaviour
{
    bool Moved;

    public void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
    }

    public void OnMouseEnter()
    {
        FindObjectOfType<AudioManager>().Play("MenuScrolling");
    }

    public void OnScroll()
    {
        FindObjectOfType<AudioManager>().Play("MenuScrolling");
    }   
}
