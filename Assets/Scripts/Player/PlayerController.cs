﻿using System.Collections;
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
    bool canAbility = true;

    IPlayer player;

    public NPlayer nPlayer;

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
    [SerializeField]
    KeyCode ability;

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
    float x, y;
    Vector3 stickDirection;

    [HideInInspector]
    public int InverterVector = 1;

    /// <summary>
    /// Contiene i comandi del Player
    /// </summary>
    public void PlayerInput()
    {
        speed = player.MovementSpeed * Time.deltaTime;
        if (stickDirection != Vector3.zero)
            Direction = stickDirection;

        stickDirection = new Vector3(x, 0, y).normalized;

        switch (nPlayer)
        {
            case NPlayer.P1:
                x = Input.GetAxis("X1");
                y = Input.GetAxis("Y1");
                break;
            case NPlayer.P2:
                x = Input.GetAxis("X2");
                y = Input.GetAxis("Y2");
                break;
            default:
                break;
        }

        // Movimento del player
        if (canMove == true)
        {
            player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), rotationSpeed);

            if ((Input.GetKey(left) || Input.GetKey(right)) && (Input.GetKey(up) || Input.GetKey(down)))
            {
                speed = speed / Math.Sqrt(2);
            }

            transform.position += stickDirection * InverterVector * (float)speed;

            if (!Input.GetKey(up) && !Input.GetKey(left) && !Input.GetKey(down) && !Input.GetKey(right) && stickDirection == Vector3.zero)
            {
                player.SM.SetBool("Run", false);
            }
            else
            {
                player.SM.SetBool("Run", true);
                //if (Input.GetKey(left))
                //{
                //    transform.position += Vector3.left * (float)speed;
                //    HorizzontalAxis = -1;
                //}
                //else if (Input.GetKey(right))
                //{
                //    transform.position += Vector3.right * (float)speed;
                //    HorizzontalAxis = 1;
                //}
                //else
                //{
                //    HorizzontalAxis = 0;
                //}
                //
                //if (Input.GetKey(up))
                //{
                //    transform.position += Vector3.forward * (float)speed;
                //    VerticalAxis = 1;
                //}
                //else if (Input.GetKey(down))
                //{
                //    transform.position += Vector3.back * (float)speed;
                //    VerticalAxis = -1;
                //}
                //else
                //{
                //    VerticalAxis = 0;
                //}
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
            FindObjectOfType<AudioManager>().Play("Dash");
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

        if (Input.GetKeyDown(ability) && !player.SM.GetBool("Ability") && canAbility)
        {
            player.SM.SetBool("Ability", true);
            canAbility = false;
            StartCoroutine(CounterCoolDownAbility());
        }
    }

    public void Dash()
    {
        transform.position += transform.forward * (player.DashDistance * Time.deltaTime);
        
    }

    IEnumerator CounterCoolDownAbility()
    {
        yield return new WaitForSeconds(player.AbilityCooldown);
        canAbility = true;
    }

    public void Jump()
    {
        // player.rigidbody.AddForce(Vector3.up * player.JumpForce);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision != null)
    //    {
    //        player.SM.SetBool("Jump", false);
    //    }
    //    else
    //    {
    //        
    //    }
    //}

    public void ResetCooldown()
    {
        StopCoroutine(CounterCoolDownAbility());
        
        canAbility = true;
        canDash = true;
    }

    public enum NPlayer { P1, P2 }
}
