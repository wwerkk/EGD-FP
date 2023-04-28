using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayRatio : MonoBehaviour
{
    public GameObject target;
    public TMP_Text parent;
    private Vector3 v;
    

    public void UpdateText() {
        v = target.transform.position;
        v /= 50.0f;
        float offset = v.magnitude;
        offset *= offset;
        float ratio = 1.0f + offset;
        parent.text = "Ratio: " + ratio.ToString();
        Debug.Log(parent);
        // yield return new WaitForSeconds(2);
        // parent.text = "";
    }
}
