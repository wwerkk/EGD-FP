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
            0.0f,
            Random.value * range);
        this.transform.position = pos;
        Debug.Log("Random spawn position: " + pos);
    }
}
