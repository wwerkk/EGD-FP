using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Synthic;

public class CreatePartial : MonoBehaviour
{
    public GameObject prefab;
    public SquareModulated playerOsc;
    private int state = 0;
    private float ratio = 0.0f;
    Vector3 pos = Vector3.zero;
    Vector3 lastPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
            ratio = playerOsc.getRatio();
            pos = this.transform.position;
            if (ratio > (float) state + 0.99f && ratio < (float) state + 1.01f && pos == lastPos) {
                Partial(ratio);
                Debug.Log("Nice ratio: " + ratio.ToString());
            }
            lastPos = pos;
    }

    void Partial(float ratio) {
        pos = this.transform.position;
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
