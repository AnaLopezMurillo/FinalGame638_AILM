using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject secondaryCamera;
    public GameObject interact;
    public GameObject interactGoBack;
    private bool isInTrigger = false;

    private void Start()
    {
        //mainCamera.enabled = true;
        //secondaryCamera.enabled = false;
        secondaryCamera.transform.position = new Vector3((float)1.12, (float)18.776, 0);

    }

    private void Update()
    {
        // switch if in trigger + Press E
        if ((isInTrigger && Input.GetKeyDown(KeyCode.E)))
        {
            SwitchCameras();
        } if (secondaryCamera.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            SwitchCameras();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interact.SetActive(true);
        isInTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interact.SetActive(false);
        isInTrigger = false;
    }

    private void SwitchCameras()
    {
        secondaryCamera.transform.position = new Vector3((float)3.99, (float)19.84, (float)2.63);
        secondaryCamera.transform.eulerAngles = new Vector3(0, 0, 0);
        if (mainCamera.activeSelf)
        {
            secondaryCamera.SetActive(true);
            mainCamera.SetActive(false);
            interact.SetActive(false);
            interactGoBack.SetActive(true);
        } else
        {
            mainCamera.SetActive(true);
            secondaryCamera.SetActive(false);
            interactGoBack.SetActive(false);
        }
    }



}
