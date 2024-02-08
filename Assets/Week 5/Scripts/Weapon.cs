using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Weapon : MonoBehaviour
{
    public float speed = 10f;
    public float timer = 0f;
    //spear does 5 damage?
    //public int damage = 5;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //from missile script week 1
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        //the spear will despawn within 5 seconds by being destroyed
        //timer example in Week 4 Task 3
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rb.MovePosition(rb.position + direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if gameobject(knight) collides with weapon, player takes damage 
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }

}
