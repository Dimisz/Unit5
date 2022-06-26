using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] prefabs;

    // playground border on the x axis
    private float xRange = 4.0f;

    // all the objects will be launched from the bottom
    private float bottomY = 0.0f;



    // variiable for initial delay 
    private float delay = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", delay, Random.Range(1.0f, 4.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        float randomX = Random.Range(-xRange, xRange);
        Instantiate(prefabs[randomIndex], new Vector3(randomX, bottomY, 0),
            prefabs[randomIndex].transform.rotation);
    }
}
