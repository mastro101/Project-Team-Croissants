using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

[RequireComponent(typeof(IPlayer))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public Vector3 Direction;

    int controller;

    string h, v, DashButton, AbilityButton;
    float cooldownDashTimer;
    bool canDash = true;
    bool canAbility = true;
    public bool canPush = true;
    [Range(1, 5)]
    public float pushForce;
    [Range(2, 5)]
    public float pushHeight;

    public IPlayer player { private get; set; }

    int NPlayer;

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
    KeyCode altDash;
    [SerializeField]
    KeyCode altAbility;

    [Range(0f, 1f)]
    [SerializeField]
    float rotationSpeed;

    [SerializeField] LayerMask obstacle;

    [HideInInspector] public Image dashTimerImage, abilityTimerImage;
    [HideInInspector] public GameObject abilityReady;
    [HideInInspector] public TextMeshProUGUI abilityCDText;
    [HideInInspector] public Animator abilityUIAnimator;


    private void Awake()
    {
        player = gameObject.GetComponent<IPlayer>();
    }

    bool setInput = false;
    public void SetController(int _nPlayer)
    {
        NPlayer = _nPlayer;
        SetController setController = FindObjectOfType<SetController>();
        if (setController != null)
        {
            if (setController.AssignedController.Count > NPlayer)
            {
                controller = FindObjectOfType<SetController>().AssignedController[NPlayer];
                h = "J" + controller + "H";
                v = "J" + controller + "V";
                DashButton = "J" + controller + "A";
                AbilityButton = "J" + controller + "X";
                setInput = true;
            }
        }
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

        if (setInput == true)
        {
            x = Input.GetAxis(h);
            y = Input.GetAxis(v);
            CheckRay();
            stickDirection = new Vector3(x, 0, y).normalized;
        }


        // Movimento del player
        if (canMove == true)
        {
            player.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction * InverterVector), rotationSpeed);

            //if ((Input.GetKey(left) || Input.GetKey(right)) && (Input.GetKey(up) || Input.GetKey(down)))
            //{
            //    speed = speed / Math.Sqrt(2);
            //}


            if (!Input.GetKey(up) && !Input.GetKey(left) && !Input.GetKey(down) && !Input.GetKey(right) && setInput == false)// && stickDirection == Vector3.zero)
            {
                player.SM.SetBool("Run", false);
                //Debug.Log(stickDirection);
                x = 0;
                y = 0;
                stickDirection = new Vector3(x, 0, y).normalized;
            }
            else
            {
                if (!player.SM.GetBool("Run") && (x != 0 || y != 0))
                    player.SM.SetBool("Run", true);
                else if (player.SM.GetBool("Run") && (x == 0 && y == 0))
                    player.SM.SetBool("Run", false);
                if (Input.GetKey(left))
                {
                    //transform.position += Vector3.left * (float)speed;
                    x = -1;
                }
                else if (Input.GetKey(right))
                {
                    //transform.position += Vector3.right * (float)speed;
                    x = 1;
                }
                else
                {
                    x = 0;
                }

                if (Input.GetKey(up))
                {
                    //transform.position += Vector3.forward * (float)speed;
                    y = 1;
                }
                else if (Input.GetKey(down))
                {
                    //transform.position += Vector3.back * (float)speed;
                    y = -1;
                }
                else
                {
                    y = 0;
                }

                if (Input.GetKey(up) || Input.GetKey(left) || Input.GetKey(down) || Input.GetKey(right))
                {
                    CheckRay();
                    stickDirection = new Vector3(x, 0, y).normalized;
                }
            }

            CheckRay();
            transform.position += stickDirection * InverterVector * (float)speed;

        }
        //// Input per il salto
        //if (Input.GetKeyDown(jump))
        //{
        //    player.SM.SetBool("Jump", true);
        //}

        // Input per il dash
        if (Input.GetKeyDown(altDash) && canDash == true)
        {
            //FindObjectOfType<AudioManager>().Play("Dash");
            player.SM.SetTrigger("Dash");
            canDash = false;
        }
        if (DashButton != null)
        {
            if (Input.GetButtonDown(DashButton) && canDash)
            {
                player.SM.SetTrigger("Dash");
                canDash = false;
            }
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

        if (Input.GetKeyDown(altAbility) && !player.SM.GetBool("Ability") && canAbility)
        {
            player.SM.SetBool("Ability", true);
            canAbility = false;
            StartCoroutine(CounterCoolDownAbility());
        }
        if (AbilityButton != null)
        {
            if (Input.GetButtonDown(AbilityButton) && !player.SM.GetBool("Ability") && canAbility)
            {
                player.SM.SetBool("Ability", true);
                canAbility = false;
                StartCoroutine(CounterCoolDownAbility());
            }
        }
    }

    public void Dash()
    {
        // StopCoroutine(FillAmountDash());
        transform.SetParent(null);
        //dashTimerImage.fillAmount = 0;
        transform.position += transform.forward * (player.DashDistance * Time.deltaTime);
        // StartCoroutine(FillAmountDash());
    }

    public void Push(IPlayer player)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        player.rigidbody.AddForce(-rb.velocity.normalized * pushForce * 500);
        player.rigidbody.AddForce(Vector3.up * pushHeight * 200);
        FindObjectOfType<AudioManager>().Play("PushSound");
    }


    /* public IEnumerator FillAmountDash()
     {
         float t = 0;
         while (dashTimerImage.fillAmount < 1)
         {
             t += Time.deltaTime;
             dashTimerImage.fillAmount = t / player.DashCooldown;
             yield return null;
         }
     }
 */
    public IEnumerator FillAmountAbility()
    {
        abilityReady.SetActive(false);
        abilityUIAnimator.gameObject.SetActive(false);
        abilityTimerImage.fillAmount = 0;
        float t = 0;
        float timeLeft = player.AbilityCooldown;
        while (abilityTimerImage.fillAmount < 1)
        {
            t += Time.deltaTime;
            abilityTimerImage.fillAmount = t / player.AbilityCooldown;

            timeLeft -= Time.deltaTime;
            abilityCDText.text = Mathf.Round(timeLeft).ToString();

            if (abilityCDText.text == "0")
            {
                abilityReady.SetActive(true);
                abilityUIAnimator.gameObject.SetActive(true);
                abilityUIAnimator.SetTrigger("Anim");
                //FindObjectOfType<AudioManager>().Play("AbilityReady");

                canAbility = true;
                break;
            }


            //if (timeLeft <= 0)
            //{
            //    readyImage.fillAmount = readyImageFillSpeed;
            //}

            //if(readyImage.fillAmount == 1)
            //{
            //    readyImage.fillAmount = 0;
            //}

            yield return null;
        }
    }

    IEnumerator CounterCoolDownAbility()
    {
        yield return new WaitForSeconds(player.AbilityCooldown);
        //canAbility = true;
    }

    public void ResetCooldown()
    {
        StopCoroutine(CounterCoolDownAbility());
        StopCoroutine(FillAmountAbility());
        //StopCoroutine(FillAmountDash());
        canAbility = true;
        canDash = true;
        // dashTimerImage.fillAmount = 1;
        abilityTimerImage.fillAmount = 1;
        abilityCDText.text = "0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        IPlayer playerPushed = collision.gameObject.GetComponent<IPlayer>();
        if (playerPushed != null && canPush)
        {
            Push(playerPushed);
        }
    }

    //public enum NPlayer { P1, P2 }

    Ray upRay, leftRay, downRay, rightRay;
    Vector3 rayOrigin;

    void CheckRay()
    {
        RaycastHit upHit, leftHit, downHit, rightHit;
        rayOrigin = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);

        upRay    = new Ray(rayOrigin, Vector3.forward);
        downRay  = new Ray(rayOrigin, Vector3.back);
        rightRay = new Ray(rayOrigin, Vector3.right);
        leftRay  = new Ray(rayOrigin, Vector3.left);

        if (Physics.Raycast(upRay, out upHit, .5f))
        {
            if (upHit.transform.gameObject.tag == "Obstacle")
            {
                if (y > 0)
                    y = 0;
            }
        }

        if (Physics.Raycast(downRay, out downHit, .5f))
        {
            if (downHit.transform.gameObject.tag == "Obstacle")
            {
                if (y < 0)
                    y = 0;
            }
        }

        if (Physics.Raycast(rightRay, out rightHit, .5f))
        {
            if (rightHit.transform.gameObject.tag == "Obstacle")
            {
                if (x > 0)
                    x = 0;
            }
        }

        if (Physics.Raycast(leftRay, out leftHit, .5f))
        {
            if (leftHit.transform.gameObject.tag == "Obstacle")
            {
                if (x < 0)
                    x = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        rayOrigin = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);

        upRay    = new Ray(rayOrigin, Vector3.forward);
        downRay  = new Ray(rayOrigin, Vector3.back);
        rightRay = new Ray(rayOrigin, Vector3.right);
        leftRay  = new Ray(rayOrigin, Vector3.left);

        Gizmos.DrawRay(upRay);
        Gizmos.DrawRay(downRay);
        Gizmos.DrawRay(rightRay);
        Gizmos.DrawRay(leftRay);
    }
}
