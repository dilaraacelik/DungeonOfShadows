using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform control;

    [SerializeField] private Rigidbody2D rbEnemy;
    [SerializeField]
    private GameObject stop1;
    [SerializeField] 
    private GameObject stop2;

    [SerializeField] private float speed;
    private void Start()
    {
        rbEnemy = gameObject.GetComponent<Rigidbody2D>();
        control = stop2.transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        if (control == stop2.transform)
            rbEnemy.velocity = new Vector2(speed, 0);
        else
            rbEnemy.velocity = new Vector2(-speed, 0);

        if (Vector2.Distance(transform.position, control.position) < 0.5f && control == stop2.transform)
            control = stop1.transform;
        if (Vector2.Distance(transform.position, control.position) < 0.5f && control == stop1.transform)
            control = stop2.transform;
    }

    
}
