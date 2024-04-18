using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://mikeloscocco.wordpress.com/2015/10/13/mario-galaxy-physics-in-unity/ //

public class GravityAttractor : MonoBehaviour
{
	public Vector3 GravitationalCenter = Vector3.zero;
	public float GravitationalConstant = -9.8f;

	public bool DistanceStrengthens = false;        // does pull weaken/strengthen with distance

	private float attractorMass;

    void Start()
    {
        attractorMass = this.GetComponent<Rigidbody>().mass;
    }

    internal void Attract(Rigidbody attractedBody)
    {
        Vector3 pullVec = FindSurface(attractedBody);           // find surface normal of PLANET
        OrientBody(attractedBody, pullVec);

        // calculate mag, dir, etc. that attractor needs to apply on body
        float pullForce = 0.0f;
        if (!DistanceStrengthens)
        {
            // inverse square law!!! I LOVE ASTROPHYSICS <33
            pullForce = GravitationalConstant * ((attractorMass * attractedBody.mass)
                / Mathf.Pow(Vector3.Distance(this.transform.position + GravitationalCenter, attractedBody.transform.position), 2));
        }
        else
        {
            // space grav
            pullForce = GravitationalConstant * (attractorMass * attractedBody.mass)
                * Vector3.Distance(this.transform.position + GravitationalCenter, attractedBody.transform.position);
        }

        // get dir vector between attracted body and the planet's grav center
        pullVec = attractedBody.transform.position - GravitationalCenter;

        // pull in that direction by the calculated force
        attractedBody.AddForce(pullForce * Time.deltaTime * pullVec.normalized);
    }

    void OrientBody(Rigidbody attractedBody, Vector3 surfaceNorm)
    {
        attractedBody.transform.localRotation = Quaternion.FromToRotation(attractedBody.transform.up, surfaceNorm) * attractedBody.rotation;
    }

    Vector3 FindSurface(Rigidbody attractedBody)
    {
        float distance = Vector3.Distance(this.transform.position, attractedBody.transform.position);
        Vector3 surfaceNorm = Vector3.zero;

        RaycastHit hit;
        if (Physics.Raycast(attractedBody.transform.position, -attractedBody.transform.up, out hit, distance))
        {
            surfaceNorm = hit.normal;
        }
        return surfaceNorm;

    }


}