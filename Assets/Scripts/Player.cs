using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Rigidbody2D playerRigidbody;
    CapsuleCollider2D footCollider;

    [Header("Movement Attributes")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;
    

    void Start()
    {
        playerRigidbody=GetComponent<Rigidbody2D>();
        footCollider=GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        PlayerMove();
    }

    void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();
    }
    void PlayerMove(){
        Vector2 delta=rawInput*playerSpeed*Time.deltaTime;
        playerRigidbody.velocity= new Vector2(delta.x, playerRigidbody.velocity.y);
    }

    void OnJump(){
        if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
        }
    }
}
