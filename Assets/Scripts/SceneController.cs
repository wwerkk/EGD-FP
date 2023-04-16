using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   
    // public String sceneName = "GameScene"";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // シーンを切り替える
    public void ClickStart() {
        Debug.Log("ClickStart");
        SceneManager.LoadScene("Playground");
    }
}
