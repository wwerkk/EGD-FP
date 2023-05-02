using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject playerObject;
    public float range = 25.0f;
    void Start()
    {
        Spawn();
    }
    
    void Update() {
        if (this.transform.position.y < -10.0f) {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Spawn();
        }
    }

    void Spawn() {
        Vector3 pos = new Vector3(
            Random.value * range,
            range * 2 + Random.value * range,
            -range + Random.value * -range
        );
        playerObject.transform.position = pos;
        // Debug.Log("Random spawn position: " + playerObject.transform.position.ToString());
    }
}
