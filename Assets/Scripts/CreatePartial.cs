using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Synthic;

public class CreatePartial : MonoBehaviour
{
    public GameObject prefab;
    public SquareModulated playerOsc;
    private int state = 0;
    private float lastRatio = 0.0f;
    private Vector3 lastPosition = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (state > 0) {
            float ratio = playerOsc.getRatio();
            // Debug.Log("Ratio: " + ratio.ToString());
            // float ratio = 0.0f;
            // Debug.Log(ratio  (float) state + 1.0f);
            if (ratio > (float) state + 0.99f && ratio < (float) state + 1.01f && ratio == lastRatio) {
                Debug.Log("Nice ratio: " + ratio.ToString());
                // playerOsc.setLastPartialPos(this.transform.position);
                // Debug.Log("Last partial pos: " + this.transform.position.ToString());
                Partial(ratio);
            }
            lastRatio = ratio;
        }
    }

    void Partial(float ratio) {
        Vector3 pos = this.transform.position;
        pos += new Vector3(0.0f, 5.0f, 0.0f);
        Debug.Log(pos.ToString());
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        SineGenerator sine = obj.GetComponent<SineGenerator>();
        sine.SetFrequency(400.0f * ratio);
        float amp = 1.0f / (ratio);
        amp = Mathf.Pow(amp, 2);
        sine.SetAmplitude(amp);
        updateState();
    }

    public void updateState() {
        state++;
        playerOsc.updateState(state);
        Debug.Log("State changed to " + state);
    }
}
