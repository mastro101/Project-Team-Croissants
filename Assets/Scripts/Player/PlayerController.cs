using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    double speed;
    public override void PlayerInput()
    {
        speed = MovementSpeed * Time.deltaTime;

        if ((Input.GetKey(left) || Input.GetKey(right)) && (Input.GetKey(up) || Input.GetKey(down)))
        {
            speed = speed / Math.Sqrt(2);
        }

        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * (float)speed;
        }
        else if (Input.GetKey(right))
        {
            transform.position += Vector3.right * (float)speed;
        }

        if (Input.GetKey(up))
        {
            transform.position += Vector3.forward * (float)speed;
        }
        else if (Input.GetKey(down))
        {
            transform.position += Vector3.back * (float)speed;
        }
        

    }
}
