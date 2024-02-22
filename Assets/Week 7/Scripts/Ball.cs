using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    Controller controller;

    //ball respawn position set to kickoff spot 
    public Rigidbody ballRespawn;
    public float respawnSpeed = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            //increment the score
            Controller.Score++;

            //return ball to original spot 
            RespawnBall();

            //Controller.goalNumber = Score;
            Controller.goalNumber = Controller.Score;
        }
    }

    private void RespawnBall()
    {
        //reset velocity here 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
