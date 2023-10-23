using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEyes : MonoBehaviour
{
    float startY;
    float startX;
    // Start is called before the first frame update
    void Start()
    {
        startX=transform.position.x;
        startY=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        transform.position=new Vector2(startX, startY*Mathf.Sin(90))*Time.deltaTime;
        Debug.Log(transform.position);
    }
}
