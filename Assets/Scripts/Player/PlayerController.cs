using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(IPlayer))]
public class PlayerController : MonoBehaviour
{
    IPlayer player;

    [SerializeField]
    KeyCode up;
    [SerializeField]
    KeyCode left;
    [SerializeField]
    KeyCode down;
    [SerializeField]
    KeyCode right;
    [SerializeField]
    KeyCode jump;
    [SerializeField]
    KeyCode dash;

    public Transform groundDetector;

    private void Awake()
    {
        player = gameObject.GetComponent<IPlayer>();
    }

    double speed;
    RaycastHit hitGround;

    /// <summary>
    /// Contiene i comandi del Player
    /// </summary>
    public void PlayerInput()
    {
        speed = player.MovementSpeed * Time.deltaTime;
        // Movimento del player
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
        
        // Input per il salto
        if (Input.GetKeyDown(jump))
        {
            player.SM.SetBool("Jump", true);
        }

        // Input per il dash
        if (Input.GetKeyDown(dash))
        {
            player.SM.SetTrigger("Dash");
        }
    }

    public void Jump()
    {
        player.rigidbody.AddForce(Vector3.up * player.JumpForce);
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
