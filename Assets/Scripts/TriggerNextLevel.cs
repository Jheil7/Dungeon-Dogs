using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNextLevel : MonoBehaviour
{
    int sceneIndex;
    Animator animator;
    float delay=3f;
    bool triggerBool;
    CinemachineVirtualCamera vcam;
    VolumeFade volumeFade;
    // Start is called before the first frame update
    void Start()
    {
        triggerBool=false;
        sceneIndex=SceneManager.GetActiveScene().buildIndex;
        animator=GetComponent<Animator>();
        vcam=FindObjectOfType<CinemachineVirtualCamera>();
        volumeFade=FindAnyObjectByType<VolumeFade>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            vcam.enabled=false;
            StartCoroutine("WaitAndLoad");
            if(volumeFade!=null){
                volumeFade.FadeAudio();
            }
        }
    }

    public IEnumerator WaitAndLoad(){
        triggerBool=true;
        yield return new WaitForSeconds(delay);
        if(sceneIndex<SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(sceneIndex+1);
        }
        else{
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    public bool Triggerbool(){
        return triggerBool;
    }
    
}
