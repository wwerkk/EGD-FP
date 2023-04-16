// using System.Diagnostics;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PitchModulator : MonoBehaviour
{
    public float pitch = 1.0f;
    public AudioSource audioSource;
    private float offset = 0.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        Vector3 v = parent.transform.position;
        // v = v.normalized;
        // Debug.Log("Position: " + v.ToString());
        v /= 50.0f;
        offset = v.magnitude;
        offset *= offset;
        // offset = v.x + v.y + v.z;
        // offset *= Mathf.Sign(v.x) * Mathf.Sign(v.y) * Mathf.Sign(v.z); 
        // offset = Convert.ToSingle(v.x * v.y * v.z * 10.0);
        // Debug.Log("Pitch offset: " + offset);
        audioSource.pitch = pitch + offset;
    }
}
