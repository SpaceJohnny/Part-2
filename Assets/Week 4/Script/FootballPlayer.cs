using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballPlayer : MonoBehaviour
{
    SpriteRenderer sr;
    public Color selectedColour;
    public Color unselectedColour;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Selected(true);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unselectedColour;
        }
    }
}