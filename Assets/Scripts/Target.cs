using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody objectRb;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float torqueRange = 10.0f;


    // playground border on the x axis
    private float xRange = 4.0f;

    // all the objects will be launched from the bottom
    private float bottomY = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        CreateInstance();
    }

    // Update is called once per frame
    void Update()
    {

        //if(transform.position.y < -5)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void CreateInstance()
    {
        float randomX = Random.Range(-xRange, xRange);
        float forceMultiplier = Random.Range(minSpeed, maxSpeed);

        // create random position
        Vector3 randomPos = new Vector3(randomX, bottomY, 0);
        transform.position = randomPos;


        objectRb = GetComponent<Rigidbody>();
        objectRb.AddForce(Vector3.up * forceMultiplier, ForceMode.Impulse);
        objectRb.AddTorque(Random.Range(-torqueRange, torqueRange),
            Random.Range(-torqueRange, torqueRange),
            Random.Range(-torqueRange, torqueRange),
            ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
