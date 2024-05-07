using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{

    // attach to all rigidbodies to orbit the world
    public GravityOrbit gravity;
    private Rigidbody rb;

    public float rotationSpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (gravity)
        {
            //Vector3 gravityUp = Vector3.zero;

            Vector3 gravityUp = (transform.position - gravity.transform.position).normalized;

            Vector3 localUp = transform.up;

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            rb.GetComponent<Rigidbody>().rotation = targetRotation;

            //transform.rotation = targetRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.GetComponent<Rigidbody>().AddForce((-gravityUp * gravity.gravity) * rb.mass);
        }
    }

    // This is the new method
    public Vector3 GetGravityUp()
    {
        if (gravity)
        {
            return (transform.position - gravity.transform.position).normalized;
        }
        return Vector3.up; // Default to world up if no gravity source is set
    }
}
