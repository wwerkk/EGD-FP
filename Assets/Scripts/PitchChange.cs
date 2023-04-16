using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChange : MonoBehaviour
{
    public float pitch = 1.0f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
