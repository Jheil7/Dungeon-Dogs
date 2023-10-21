using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Rigidbody2D playerRigidbody;
    BoxCollider2D footCollider;
    Animator animator;
    bool facingLeft = true;
    bool alive;
    [SerializeField] int jumpCount = 0;

    [Header("Movement Attributes")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;
    

    void Start()
    {
        alive=true;
        playerRigidbody=GetComponent<Rigidbody2D>();
        footCollider=GetComponent<BoxCollider2D>();
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        alive=!animator.GetBool("Dead");
    }

    private void FixedUpdate() {
        if(!alive){playerRigidbody.velocity=Vector2.zero;}
        else{
        PlayerMove();
        if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            jumpCount = 0;
            animator.SetBool("IsJumping", false);
        } else {
            animator.SetBool("IsJumping", true);
        }}
    }

    void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();
        if(rawInput.x > 0 && facingLeft) Flip();
        if(rawInput.x < 0 && !facingLeft) Flip();
    }
    void PlayerMove(){
        Vector2 delta=rawInput*playerSpeed*Time.deltaTime;
        playerRigidbody.velocity= new Vector2(delta.x, playerRigidbody.velocity.y);
        if(delta != Vector2.zero) animator.SetFloat("Speed", 1f);
        else animator.SetFloat("Speed", 0f);
    }

    void OnJump(){
        if(jumpCount < 1){
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
            playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    void Flip() {
        if(alive){
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            facingLeft = !facingLeft;
        }

    }
}
