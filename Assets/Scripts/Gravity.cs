using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public Transform gravityTarget;

    public float gravity = -9.81f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gravityTarget);
        rb = GetComponent<Rigidbody>();
        Debug.Log(rb.mass);
    }

    void FixedUpdate()
    {
        ProcessGravity();
        Debug.Log(rb.transform);
    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(diff.normalized * gravity * (rb.mass));
        Debug.DrawRay(transform.position, diff.normalized, Color.red);
    }
}
