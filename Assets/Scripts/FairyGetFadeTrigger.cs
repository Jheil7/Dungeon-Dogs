using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyGetFadeTrigger : GetFadeTrigger
{
    FairyTriggerNextLevel levelTrigger;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        levelTrigger=FindObjectOfType<FairyTriggerNextLevel>();
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