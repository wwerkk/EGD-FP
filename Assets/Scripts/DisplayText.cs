using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour {
    public TMP_Text target;

    public void Display(string text, float time) {
        StartCoroutine(Coroutine(text, time));
    }

    IEnumerator Coroutine(string text, float time) {
        Debug.Log("Started coroutine...");
        target.text = text;
        yield return new WaitForSeconds(time);
        target.text = "";
        Debug.Log("Finished coroutine...");
    }
}
