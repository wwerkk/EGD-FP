// using System.Diagnostics;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOscillator : MonoBehaviour
{
    public double frequency = 50.0;
    private double modulator = 0.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;
    private double gain = 0.05;

    // Hijack the OnAudioFilterRead method to generate a sine wave
    private void OnAudioFilterRead(float[] data, int channels) {
        increment = (frequency + modulator) * 2.0 * Mathf.PI / sampling_frequency;
        for (int i = 0; i < data.Length; i += channels) {
            phase += increment;
            for (int j = 0; j < channels; j++) {
                data[i + j] = (float)(gain * Mathf.Sin((float)phase));
            }
            if (phase > (Mathf.PI * 2)) {
                phase -= (Mathf.PI * 2);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameObject parent = transform.parent.gameObject;
        Vector3 v = parent.transform.position;
        // Debug.Log("Position: " + v);
        modulator = v.sqrMagnitude * v.x * v.y * v.z * 0.01;
        // Debug.Log("Vector magnitude: " + modulator);
    }
}
