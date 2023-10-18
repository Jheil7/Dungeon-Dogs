using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float moveSpeed= 1.0f;
    CapsuleCollider2D frontCollider;
    void Start()
    {
        myRigidBody=GetComponent<Rigidbody2D>();
        frontCollider=GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        myRigidBody.velocity=new Vector2 (moveSpeed*Time.deltaTime, 0.0f);
    }

    void OnTriggerExit2D(Collider2D other) {
        moveSpeed=-moveSpeed;
        FlipEnemyFacing();
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Debug.Log("Player Dead");
            //Add player death animation etc.
        }
    }

    void FlipEnemyFacing(){
        transform.localScale= new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)),1f);
    }
}
