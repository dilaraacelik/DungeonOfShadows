using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputActionReference movement;
    private Vector2 movementVector;

    // Update is called once per frame
    void Update()
    {
        movementVector = movement.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * (moveSpeed * Time.fixedDeltaTime));
    }
}
