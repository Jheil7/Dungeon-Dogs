using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFadeTrigger : MonoBehaviour
{
    TriggerNextLevel levelTrigger;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        levelTrigger=FindObjectOfType<TriggerNextLevel>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetTrigger();
        StartFade();
    }

    void GetTrigger(){
        levelTrigger.Triggerbool();
    }

    void StartFade(){
        if(levelTrigger.Triggerbool()==true){
            animator.SetTrigger("End");
        }
    }
}
