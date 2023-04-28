using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public float range = 50.0f;
    void Start()
    {
        Vector3 pos = new Vector3(
            Random.value * range,
            range * 2 + Random.value * range,
            Random.value * range);
        this.transform.position = pos;
        Debug.Log("Random spawn position: " + pos);
    }
    
    void Update() {
        Vector3 currentPos = this.transform.position;
        if (currentPos.y < -5.0f) {
           Start();
        }
    }
}
