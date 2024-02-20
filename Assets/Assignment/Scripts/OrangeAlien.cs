using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using lerp
//linear interpolate between two values 
public class OrangeAlien : MonoBehaviour
{
    private Vector3 endValue = new Vector3(3, -1, 0);
    private Vector3 startValue;

    //changes movement from linear to non-linear 
    public AnimationCurve alienAnimationCurve;

    //it takes 10 seconds to go from endValue position to startValue Position
    private float animationTime = 10f;
    //time passed
    private float elapsedTime;

    void Start()
    {
        startValue = transform.position;
    }

    void Update()
    {
        //using percentage allows for a smoother transition 
        //instead of time.deltatime
        //source: https://www.youtube.com/watch?v=MyVY-y_jK1I&list=LL&index=2 
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / animationTime;

        //update position using lerp 
        transform.position = Vector3.Lerp(startValue, endValue, percentageComplete);
    }
}
