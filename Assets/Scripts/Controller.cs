using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Camera playerCamera;

    public float rotationSpeed = 50.0f;
    public float translationSpeed = 5.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool cameraCanMove = true;
    public float mouseSensitivity = 2f;

    public bool invertCamera = false;
    public float maxLookAngle = 50f;

    /* Use this for initialization
    void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {

        //yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;

        //if (!invertCamera)
        //{
        //    pitch -= mouseSensitivity * Input.GetAxis("Mouse Y");
        //}
        //else
        //{
        //    // Inverted Y
        //    pitch += mouseSensitivity * Input.GetAxis("Mouse Y");
        //}

        //// Clamp pitch between lookAngle
        //pitch = Mathf.Clamp(pitch, -maxLookAngle, maxLookAngle);

        //transform.localEulerAngles = new Vector3(0, yaw, 0);
        //playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);



        if (Input.GetKey("left"))
        {
            transform.Rotate(0f, -1.0f * rotationSpeed * Time.deltaTime, 0f, Space.Self);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
        }

        //Vector3 travelDir = transform.TransformDirection(Vector3.forward); //get in world coordinates
        Vector3 travelDir = transform.forward;
        //travelDir.y = 0.0f; //prevent user from changing altitude above plane
        travelDir.Normalize();

        if (Input.GetKey("up"))
        {
            transform.Translate(travelDir * Time.deltaTime * translationSpeed, Space.World);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(-travelDir * Time.deltaTime * translationSpeed, Space.World);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("collision!");
    }
}