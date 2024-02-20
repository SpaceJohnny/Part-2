using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    //scene pauses after one arrow has been fired 
    //fixed 
    public GameObject arrowPrefab;
    public GameObject arrowSpawn;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();

        //a listener registers a function to button 
        button.onClick.AddListener(FireArrow);
    }

    //quaternion.euler (90) to make sure the arrows spawn pointing left 
    void FireArrow()
    {
        Instantiate(arrowPrefab, arrowSpawn.transform.position, Quaternion.Euler(0,0,90));
    }
}
