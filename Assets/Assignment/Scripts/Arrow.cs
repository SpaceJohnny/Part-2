using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour
{

    public float speed = 10f;
    public float timer = 0f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //from missile script week 1
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        //the arrow will despawn within 5 seconds by being destroyed
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

    //if the arrow collides with the player, load game over screen 
    //if not destory game object 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cowgirl"))
        {
            SceneManager.LoadScene("Game Over Screen");
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
