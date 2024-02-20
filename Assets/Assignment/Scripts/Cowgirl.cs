using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //click on world space 
            //move rb in fixed update
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Speed", movement.magnitude);
    }
}
