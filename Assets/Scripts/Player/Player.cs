using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Rigidbody2D playerRigidbody;
    BoxCollider2D footCollider;
    Animator animator;
    bool facingLeft;

    [Header("Respawn Attributes")]
    [SerializeField] bool isControllable;
    [SerializeField] bool isDead;

    [Header("Movement Attributes")]
    [SerializeField] bool isGrounded;
    [SerializeField] bool jumpEnabled;
    [SerializeField] int jumpCount;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;
    [SerializeField] float jumpHeightBouncy;
    
    public bool IsControllable{get;set;}

    void Awake(){
        facingLeft = true;
        IsControllable = true;
        isDead = false;
        jumpCount = 2;
        isGrounded = false;
    }

    void Start()
    {
        //Application.targetFrameRate=60;
        playerRigidbody=GetComponent<Rigidbody2D>();
        footCollider=GetComponentInChildren<BoxCollider2D>();
        animator=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
        isDead = animator.GetBool("dead");
        CheckGrounded();
        CheckFalling();
        Jump();
        PlayerMove();
    }

    bool CanMove() {
        return !isDead && IsControllable;
    }

    void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();
        if(rawInput.x > 0 && facingLeft && CanMove()) Flip();
        if(rawInput.x < 0 && !facingLeft && CanMove()) Flip();
    }
    
    void PlayerMove(){
        if(CanMove()){
            Vector2 delta=rawInput*playerSpeed;
            playerRigidbody.velocity= new Vector2(delta.x, playerRigidbody.velocity.y);
            if(delta.x != 0) animator.SetFloat("speed", 1f);
            else animator.SetFloat("speed", 0f);            
        } else {
            playerRigidbody.velocity=Vector2.zero;
        }
    }

    void JumpForce(float heightToJump){
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        playerRigidbody.AddForce(Vector2.up*heightToJump, ForceMode2D.Impulse);
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(jumpCount==2){
                if(footCollider.IsTouchingLayers(LayerMask.GetMask("Bounce"))){
                    JumpForce(jumpHeightBouncy);
                }
                else{
                    JumpForce(jumpHeight);
                }
                
                jumpCount--;
                jumpEnabled = false;
                StartCoroutine("JumpCd");
                isGrounded=false;
            }
            else if(jumpEnabled && jumpCount==1){
                animator.SetBool("doubleJump", true);
                JumpForce(jumpHeight);
                jumpCount--;
            }
        }
        if(Input.GetButtonUp("Jump")){
            if(playerRigidbody.velocity.y>Mathf.Epsilon){
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, playerRigidbody.velocity.y/5);
            }
        }
    }

    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

    IEnumerator JumpCd(){
        yield return new WaitForSeconds(0.05f);
        jumpEnabled = true;
    }

    void CheckGrounded(){
        if(!isGrounded){
            if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))||footCollider.IsTouchingLayers(LayerMask.GetMask("Bounce"))){
                animator.SetBool("doubleJump", false);
                isGrounded = true;
                jumpCount = 2;
            }
        }
        animator.SetBool("jump", !isGrounded);
    }

    void CheckFalling(){
        if(playerRigidbody.velocity.y<-1&&jumpCount>1){
            isGrounded=false;
            jumpCount=1;
            }
    }
    

    IEnumerator GroundedWait(){
        yield return new WaitForSeconds(0.1f);
        isGrounded=true;
    }
}
