using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool clickOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead;
    public HealthBar healthbar; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;

        //health = PlayerPrefs.GetFloat("health", maxHealth);
        //SendMessage("health", PlayerPrefs.GetFloat("health", maxHealth), SendMessageOptions.DontRequireReceiver);

        //the use of player prefrences to store knight's health value
        //health = PlayerPrefs.GetFloat("KnightHealth", maxHealth);
        //did not work 

        isDead = false;

        //Sync the initial health 
        //SendMessage("HealthSync", health);
    }

    private void FixedUpdate()
    {
        //no need for { if one word
        //return tells it to stop doing the function
        if(isDead) return;
        // transform.position is vector 3
        movement = destination - (Vector2)transform.position;
        if(movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        //! not clickOnSelf
        if (Input.GetMouseButtonDown(0) && !clickOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            //click on world space 
            //move rb in fixed update
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //set attack parameter on right mouse button 
        //(1) is right (0) is left 
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("Movement", movement.magnitude);
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickOnSelf = true;
        gameObject.SendMessage("TakeDamage", 1);
        //TakeDamage(1);
        //healthbar.TakeDamage(1);

    }
    
    private void OnMouseUp()
    {
        clickOnSelf = false;
    }

    //(float damage) is a parameter
    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health <= 0)
        {
            isDead = true;
            //die
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }

        //health saved by using PlayerPrefs
        //PlayerPrefs.SetFloat("KnightHealth", health);

        //healthbar.SendMessage("UpdateHealth", health);
    }


}
