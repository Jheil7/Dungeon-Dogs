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
            Debug.Log(playerRigidbody.velocity);
            if(delta.x != 0) animator.SetFloat("speed", 1f);
            else animator.SetFloat("speed", 0f);            
        } else {
            playerRigidbody.velocity=Vector2.zero;
        }
    }

    void JumpForce(){
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
        playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(isGrounded&&jumpCount==2){
                JumpForce();
                jumpCount--;
                jumpEnabled = false;
                StartCoroutine("JumpCd");
            }
            else if(!isGrounded && jumpEnabled && jumpCount==1){
                animator.SetBool("doubleJump", true);
                JumpForce();
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
        isGrounded = false;
        if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            animator.SetBool("doubleJump", false);
            isGrounded = true;
            jumpCount = 2;
        }
        animator.SetBool("jump", !isGrounded);
    }
}
