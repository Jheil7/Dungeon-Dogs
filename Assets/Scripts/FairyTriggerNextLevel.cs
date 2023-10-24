using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FairyTriggerNextLevel : TriggerNextLevel
{
    CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        vcam=FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Light"){
            vcam.enabled=false;
            StartCoroutine("WaitAndLoad");
        }
    }
    
}
