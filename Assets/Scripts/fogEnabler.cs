using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Starting in 2 seconds.
// Screen will go black every 1 second.
// Also could be done using Time.time and modulo, but whatever

public class fogEnabler : MonoBehaviour
{
    // private int delta = 30;
    // Start is called before the first frame update
    void Start()
    {
        // RenderSettings.fog = false;   
        // InvokeRepeating("Fogger", 2.0f, 0.7f);
        // InvokeRepeating("Unfogger", 2.0f, 0.2f);
        Debug.Log("This should work...");

    }

    // Update is called every frame
    void Update() {
        double density = (Mathf.Sin(Time.time)) * 0.5 + 0.5;
        density *= 0.3;
        RenderSettings.fogDensity = (float) density;
        // // Debug.Log((int)Time.timeSinceLevelLoad);
        // if ((int)Time.timeSinceLevelLoad % 3 == 0) {
        //     Unfogger();
        // } else {
        //     Fogger();
        // }

    }

    // void Fogger()
    // {   
    //     RenderSettings.fogDensity = 0.4f;
    //     // RenderSettings.fogDensity = UnityEngine.Random.value;
    //    Debug.Log("Foggggggg DDDDDD:");
    // }

    // void Unfogger() {
    //     RenderSettings.fogDensity = 0.0f;
    //     Debug.Log("No more foggggggg :DDDDDDD");
    // }
}
