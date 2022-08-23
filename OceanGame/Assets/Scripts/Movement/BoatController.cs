using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    Rigidbody rb;
    public Transform Director;
    private float force = 1;            //the stopping force in the water

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
            print("input");
            rb.AddForceAtPosition(Vector3.forward, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForceAtPosition(Vector3.back, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForceAtPosition(Vector3.left, Director.position, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForceAtPosition(Vector3.right, Director.position, ForceMode.Force);
        }

    }
}
