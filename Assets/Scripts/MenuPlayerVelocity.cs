using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerVelocity : MonoBehaviour
{

    Rigidbody2D playerRb;
    int playerSpeed=300;
    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        playerRb.velocity=Vector2.right*playerSpeed*Time.deltaTime;
    }
}
