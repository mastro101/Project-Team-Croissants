using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerBase
{

    [SerializeField]
    int id;
    public override int ID
    {
        get
        {
            return id;
        }
    }

    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode right;

    [SerializeField]
    float movementSpeed;
    public override float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }

        set
        {
            movementSpeed = value;
        }
    }

    private void Update()
    {
        //PlayerInput();
    }

    public override void PlayerInput()
    {
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(right))
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(up))
        {
            transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(down))
        {
            transform.position += new Vector3(0, 0,-movementSpeed * Time.deltaTime);
        }

    }
}
