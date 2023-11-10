using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private float damage = 5;
    [SerializeField]
    private float totalHealth = 20;
    [SerializeField] 
    private Animator animator;
    private Vector2 movementVector;
    [SerializeField] 
    private InputActionReference movement;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private static readonly int TotalHealth = Animator.StringToHash("TotalHealth");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = movement.action.ReadValue<Vector2>();
        
        animator.SetFloat(Horizontal,movementVector.x);
        animator.SetFloat(Vertical,movementVector.y);
        animator.SetFloat(TotalHealth,totalHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            totalHealth -= damage;
            if (totalHealth < 0)
                totalHealth = 0;
        }
    }
    
}
