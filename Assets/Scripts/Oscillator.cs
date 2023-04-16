using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;
    private double gain = 0.05;

    private void OnAudioFilterRead(float[] data, int channels) {
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;
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
}
