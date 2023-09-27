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
    [SerializeField] private Animator animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");

    // Update is called once per frame
    void Update()
    {
        movementVector = movement.action.ReadValue<Vector2>();
        
        animator.SetFloat(Horizontal,movementVector.x);
        animator.SetFloat(Vertical,movementVector.y);
        animator.SetFloat(Speed,movementVector.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * (moveSpeed * Time.fixedDeltaTime));
    }
}
