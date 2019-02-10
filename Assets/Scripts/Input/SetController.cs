using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    string xAxis, yAxis, a;
    int controllerNumber;
    [HideInInspector]
    public List<int> assignedController = new List<int>();
    [SerializeField]


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
                SetControllerNumber(i);
                assignedController.Add(i);
                Debug.Log("Add " + i);
            }
        }
    }

    void SetControllerNumber(int n)
    {
        controllerNumber = n;
        //xAxis = "J" + controllerNumber + "X";
        //yAxis = "J" + controllerNumber + "Y";
        a = "J" + controllerNumber + "A";
    }

}
