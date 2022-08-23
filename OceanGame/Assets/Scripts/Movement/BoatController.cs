using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    Rigidbody rb;
    public Transform Director;
    private float speed = 1;            //the stopping force in the water       //speed for game, 1 for testing for some reason


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForceAtPosition(Vector3.forward * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(Vector3.back * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(Vector3.left * speed, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(Vector3.right * speed, Director.position, ForceMode.Force);
        }

    }
}
