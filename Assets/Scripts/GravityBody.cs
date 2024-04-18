using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor CurrentAttraction;
    public Rigidbody objectBody;

    void FixedUpdate() 
    {
        if (CurrentAttraction != null && objectBody != null)
        {
            CurrentAttraction.Attract(objectBody);
        } 
    }
}
