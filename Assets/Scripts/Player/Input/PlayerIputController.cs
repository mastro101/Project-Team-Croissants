using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;

public class PlayerIputController : MonoBehaviour
{
    [SerializeField]
    PlayerInput input;

    Vector2 Direction;

    private void Awake()
    {
        input.Player.Movement.performed += ctx => SetDirection(ctx.ReadValue<Vector2>());
    }

    private void Update()
    {
        transform.position += new Vector3(Direction.x, 0, Direction.y) * Time.deltaTime * 8;
    }

    void SetDirection(Vector2 _direction)
    {
        Direction = _direction;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
