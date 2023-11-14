using System.Collections;
using System.Collections.Generic;
using FunkyCode.Rendering.Day;
using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        boxCollider2D=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Feet"){
            //start break animation
        }
    }

    void BreakPlatform(){

    }

    //add event at end of animation
    void BreakTimer(){
        spriteRenderer.enabled=false;
        boxCollider2D.enabled=false;
    }

}
