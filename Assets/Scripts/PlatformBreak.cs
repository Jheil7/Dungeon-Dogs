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

    private void OnCollisionEnter2D(Collision2D other) {
        StartCoroutine("BreakTimer");
    }

    void BreakPlatform(){

    }

    IEnumerator BreakTimer(){
        yield return new WaitForSeconds(2.0f);
        spriteRenderer.enabled=false;
        boxCollider2D.enabled=false;
    }

}
