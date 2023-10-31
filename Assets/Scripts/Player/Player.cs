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
    bool facingLeft = true;
    bool isControllable;
    bool isDead;
    public bool canDoubleJump;
    public bool canGroundJump;
    [SerializeField] int jumpCount = 0;
    [Header("Movement Attributes")]
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;
    
    public bool IsControllable{
        get{return isControllable;}
        set{isControllable=value;}
        }

    void Start()
    {
        canGroundJump=true;
        isDead=false;
        isControllable=true;
        playerRigidbody=GetComponent<Rigidbody2D>();
        footCollider=GetComponentInChildren<BoxCollider2D>();
        animator=GetComponent<Animator>();
        animator.SetBool("IsJumping",false);
        animator.SetBool("isLanding",false);
    }

    // Update is called once per frame
    void Update()
    {
        // if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))&&!animator.GetBool("IsJumping")) {
        //     jumpCount = 0;
        //     canDoubleJump=true;
        //     }
        // else {
        //     animator.SetBool("IsJumping", true);
        //     }    
        CheckDeath();
        PlayerMove();
        NewJump();
        CheckGrounded();
 

    }

    private void FixedUpdate() {
        CheckDeath();
        PlayerMove();
        NewJump();
        CheckGrounded();
    }

    void OnMove(InputValue value){
        rawInput=value.Get<Vector2>();
        if(rawInput.x > 0 && facingLeft) Flip();
        if(rawInput.x < 0 && !facingLeft) Flip();
    }
    void PlayerMove(){
        if(isControllable){
            Vector2 delta=rawInput*playerSpeed*Time.deltaTime;
            playerRigidbody.velocity= new Vector2(delta.x, playerRigidbody.velocity.y);
            if(delta.x != 0) animator.SetFloat("Speed", 1f);
            else animator.SetFloat("Speed", 0f);
            // if(playerRigidbody.velocity.y<Mathf.Epsilon){
            //     animator.SetBool("IsJumping",false);
            //     animator.SetBool("isLanding",true);
            // }
            // else if(playerRigidbody.velocity.y>=Mathf.Epsilon){
            //     animator.SetBool("IsJumping",true);
            //     animator.SetBool("isLanding",false);
            // }
            
            }
            
        
        else{
            playerRigidbody.velocity=Vector2.zero;
        }
    }

    // void OnJump(){
    //     if(jumpCount < 1){
    //         playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
    //         playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
    //         jumpCount++;
    //     }
    // }

    void NewJump(){
        if(Input.GetButtonDown("Jump")){
            if(canGroundJump&&jumpCount==2){
                canGroundJump=false;
                jumpCount--;
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
                playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
                canDoubleJump=false;
                StartCoroutine("JumpCd");
                }
            else if(jumpCount==1&&canDoubleJump){
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
                playerRigidbody.AddForce(Vector2.up*jumpHeight, ForceMode2D.Impulse);
                canDoubleJump=false;
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
        yield return new WaitForSeconds(0.1f);
        canGroundJump=true;
        canDoubleJump=true;
    }

    void CheckDeath(){
        isDead=!animator.GetBool("Dead");
        if(!isDead){
            IsControllable=false;
        }
        else{
            IsControllable=true;
        }
    }

    void CheckGrounded(){
        if(footCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))&&canGroundJump) {
            jumpCount=2;
            canDoubleJump=true;
            animator.SetBool("IsJumping", false);
        } 
        else {
            animator.SetBool("IsJumping", true);
            } 
    }
}
