using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            //incriment the score
            Controller.Score++;

            //return ball to original spot 
            //ReturnBall();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
