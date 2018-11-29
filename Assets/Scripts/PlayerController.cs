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
        PlayerControls();
    }

    void PlayerControls()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);

        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

        }
    }

}
