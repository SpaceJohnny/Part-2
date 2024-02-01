using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawner;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (counter < 5)
        {
            counter += Time.deltaTime;
        }
        else if (counter > 5)
        {
            Vector3 randSpawner = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            Instantiate(spawner, randSpawner, transform.rotation = Quaternion.Euler(0, 0, Random.Range(-180, 180)));
            counter = 0;

            //spawner.GetComponent<SpriteRenderer>().sprite = planeArray[Random.Range(0, 3)]; 
        }
    }
}
