using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Cowgirl : MonoBehaviour
{
    //public rb and animator to add components on unity
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    Vector2 destination;
    public float speed = 3;

    //Based movement from the knight script 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        //stops the animation from bugging out 
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
        //Debug.Log(movement.x);

        //play left animation when x value is less than 0 
        if (movement.x < 0)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

        //play right animation when x value is greater than 0
        if (movement.x > 0)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //click on world space to move 
            //move rb in fixed update
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Speed", movement.magnitude);
    }
}
