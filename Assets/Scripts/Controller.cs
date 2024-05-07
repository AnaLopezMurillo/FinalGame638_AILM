using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Camera playerCamera;
    public float rotationSpeed = 50.0f;
    public float translationSpeed = 10.0f;
    public float jumpStrength = 7.0f;

    private Rigidbody rb;
    public Transform planetCenter;  // Assign this to the transform of the planet's center in the inspector

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // Since we are using custom gravity
    }

    void Update()
    {
        if (!CharacterInteraction.isDialogueActive)
        {
            HandleRotation();
            HandleMovement();
            HandleJump();
        }

        //ApplyGravity();
    }

    void HandleRotation()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(0f, -1.0f * rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
    }

    void HandleMovement()
    {
        Vector3 travelDir = transform.forward;
        if (Input.GetKey("up"))
        {
            transform.Translate(travelDir * Time.deltaTime * translationSpeed, Space.World);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(-travelDir * Time.deltaTime * translationSpeed, Space.World);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDirection = (transform.position - planetCenter.position).normalized;
            rb.AddForce(jumpDirection * jumpStrength, ForceMode.Impulse);
        }
    }

    //void ApplyGravity()
    //{
    //    Vector3 gravityDirection = (planetCenter.position - transform.position).normalized;
    //    rb.AddForce(gravityDirection * 20f); 
    //}

    bool IsGrounded()
    {
        Vector3 groundDirection = (planetCenter.position - transform.position).normalized;
        return Physics.Raycast(transform.position, -groundDirection, 1.1f);
    }
}
