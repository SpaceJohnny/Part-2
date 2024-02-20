using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    //scene pauses after one arrow has been fired 
    public Arrow arrowPrefab;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        //a listener registers a function to button 
        button.onClick.AddListener(FireArrow);
    }

    // Update is called once per frame
    void FireArrow()
    {
        Instantiate(arrowPrefab, transform.position, Quaternion.identity);
    }
}
