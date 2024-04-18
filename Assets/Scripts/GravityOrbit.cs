using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{

    public float gravity = -9.81f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GravityCtrl>())
        {
            // if this object has a gravity script, set this as the planet
            other.GetComponent<GravityCtrl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
