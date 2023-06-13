using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    
    public float speed;
    private Vector2 movementInput;

    private void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = movementInput * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}