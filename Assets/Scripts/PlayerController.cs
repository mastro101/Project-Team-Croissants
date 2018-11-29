using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BasePlayer
{
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
        PlayerInput();
    }

    public override void PlayerInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0,-movementSpeed * Time.deltaTime);
        }

    }

    

}
