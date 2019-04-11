using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    int controllerNumber;
    [HideInInspector]
    public List<int> AssignedController = new List<int>();

    public static SetController Instance { get; private set; }

    [HideInInspector]
    public int NPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AssigneController()
    {
        for (int i = 1; i <= 16; i++)
        {
            if (AssignedController.Contains(i))
            {
                continue;
            }

            if (Input.GetButtonDown("J" + i + "A"))
            {
                AssignedController.Add(i);
                Debug.Log("Add " + i);
            }
        }
    }
}
