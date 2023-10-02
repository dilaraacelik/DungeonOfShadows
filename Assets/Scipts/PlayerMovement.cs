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
    private Vector2 idleVector;
    [SerializeField] private Animator animator;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IdleHorizontal = Animator.StringToHash("Idle_Horizontal");
    private static readonly int IdleVertical = Animator.StringToHash("Idle_Vertical");

    // Update is called once per frame
    void Update()
    {
        movementVector = movement.action.ReadValue<Vector2>();
        idleVector = movement.action.ReadValue<Vector2>();
        
        if (idleVector.x != 0 || idleVector.y != 0)
        {
            animator.SetFloat(IdleHorizontal,idleVector.x);
            animator.SetFloat(IdleVertical,idleVector.y);
        }

        animator.SetFloat(Horizontal,movementVector.x);
        animator.SetFloat(Vertical,movementVector.y);
        animator.SetFloat(Speed,movementVector.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * (moveSpeed * Time.fixedDeltaTime));
    }
}
