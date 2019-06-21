using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISound : MonoBehaviour
{
    public void OnMouseDown()
    {
        FindObjectOfType<AudioManager>().Play("MenuFinalSelection");
    }

    public void OnMouseEnter()
    {
        FindObjectOfType<AudioManager>().Play("MenuScrolling");
    }
}
