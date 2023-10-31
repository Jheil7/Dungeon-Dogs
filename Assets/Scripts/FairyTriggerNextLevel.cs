using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FairyTriggerNextLevel : TriggerNextLevel
{
    CinemachineVirtualCamera vcam;
    float delay=3f;
    bool triggerBool;
    // Start is called before the first frame update
    void Start()
    {
        triggerBool = false;
        vcam=FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Light"){
            vcam.enabled=false;
            StartCoroutine("WaitAndLoadEpilogue");
        }
    }

    IEnumerator WaitAndLoadEpilogue(){
        triggerBool = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Epilogue"); 
    }

    public new bool Triggerbool() {
        return triggerBool;
    }

}