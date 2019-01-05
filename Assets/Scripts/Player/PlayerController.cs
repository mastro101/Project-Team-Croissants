using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(IPlayer))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public Vector3 Direction;

    float cooldownDashTimer;
    bool canDash = true;

    IPlayer player;

    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode right;
    //[SerializeField]
    //KeyCode jump;
    [SerializeField]
    KeyCode dash;

    [Range(0f, 1f)]
    [SerializeField]
    float rotationSpeed;

    public Transform groundDetector;

    private void Awake()
    {
        player = gameObject.GetComponent<IPlayer>();
    }

    double speed;

    float HorizzontalAxis, VerticalAxis;


    /// <summary>
    /// Contiene i comandi del Player
    /// </summary>
    public void PlayerInput()
    {
        speed = player.MovementSpeed * Time.deltaTime;
        Direction = new Vector3(HorizzontalAxis, 0, VerticalAxis);
        player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), rotationSpeed);


        // Movimento del player
        if (canMove == true)
        {

            if ((Input.GetKey(left) || Input.GetKey(right)) && (Input.GetKey(up) || Input.GetKey(down)))
            {
                speed = speed / Math.Sqrt(2);
            }

            if (!Input.GetKey(up) && !Input.GetKey(left) && !Input.GetKey(down) && !Input.GetKey(right))
            {

            }
            else
            {
                if (Input.GetKey(left))
                {
                    transform.position += Vector3.left * (float)speed;
                    HorizzontalAxis = -1;
                }
                else if (Input.GetKey(right))
                {
                    transform.position += Vector3.right * (float)speed;
                    HorizzontalAxis = 1;
                }
                else
                {
                    HorizzontalAxis = 0;
                }

                if (Input.GetKey(up))
                {
                    transform.position += Vector3.forward * (float)speed;
                    VerticalAxis = 1;
                }
                else if (Input.GetKey(down))
                {
                    transform.position += Vector3.back * (float)speed;
                    VerticalAxis = -1;
                }
                else
                {
                    VerticalAxis = 0;
                }
            }
        }
        //// Input per il salto
        //if (Input.GetKeyDown(jump))
        //{
        //    player.SM.SetBool("Jump", true);
        //}

        // Input per il dash
        if (Input.GetKeyDown(dash) && canDash == true)
        {
            player.SM.SetTrigger("Dash");
            canDash = false;
        }

        if (canDash == false)
        {
            cooldownDashTimer += Time.deltaTime;
            if (cooldownDashTimer >= player.DashCooldown)
            {
                cooldownDashTimer = 0;
                canDash = true;
            } 

        }
    }

    public void Dash()
    {
        transform.position += transform.forward * (player.DashDistance * Time.deltaTime);
        
    }


    public void Jump()
    {
        // player.rigidbody.AddForce(Vector3.up * player.JumpForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            player.SM.SetBool("Jump", false);
        }
        else
        {
            
        }
    }
}
