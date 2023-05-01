using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Synthic;

public class ColliderScript : MonoBehaviour
{
    public GameObject prefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player collided...");
            GameObject obj = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            SineGenerator sine = obj.GetComponent<SineGenerator>();
            sine.SetFrequency(400.0f);

            // Change player state
            other.GetComponent<CreatePartial>().updateState();
            // Destroy the parent object and all its children
            Destroy(transform.parent.gameObject);
        }
    }
}
