using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using lerp
//linear interpolate between two values 
public class OrangeAlien : MonoBehaviour
{
    private Vector3 endPosition = new Vector3(5, -2, 0);
    private Vector3 startPosition;

    public AnimationCurve alienAnimationCurve;

    private float desiredDuration = 10f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
    }
}
