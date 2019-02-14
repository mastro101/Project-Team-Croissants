using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    int controllerNumber;
    [HideInInspector]
    public List<int> assignedController = new List<int>();

    public void AssigneController()
    {
        for (int i = 1; i <= 2; i++)
        {
            if (assignedController.Contains(i))
            {
                continue;
            }

            if (Input.GetButtonDown("J" + i + "A"))
            {
                assignedController.Add(i);
                Debug.Log("Add " + i);
            }
        }
    }
}
