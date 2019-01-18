using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbuggo : MonoBehaviour
{

    [SerializeField] private InputMaster controls;
    [SerializeField] private Vector3 _moveaxis;

    public float _speed = 10;

    private void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player1.Movement.performed += Movement_performed;
    }

    private void Movement_performed(UnityEngine.Experimental.Input.InputAction.CallbackContext context)
    {
        _moveaxis = context.ReadValue<Vector3>();
        Debug.Log("Move Axis {_moveAxis}");
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_moveaxis.x * Time.deltaTime * _speed, 0, _moveaxis.z * Time.deltaTime * _speed);
    }

    /*

     public InputMaster controls;

     private void Awake()
     {
         controls.Player1.Dash.performed += ctx => Dash();
     }

     private void OnEnable()
     {
         controls.Enable();
     }

     private void OnDisable()
     {
         controls.Disable();
     }

     void Dash()
     {
         Debug.Log("ho dashato ma non è vero");
     }


     */

}
