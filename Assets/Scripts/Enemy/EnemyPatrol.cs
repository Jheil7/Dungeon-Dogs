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
        frontCollider=GetComponentInChildren<CapsuleCollider2D>();
        Physics.IgnoreLayerCollision(7,7);
    }

    void FixedUpdate()
    {
        myRigidBody.velocity=new Vector2 (Mathf.Sign(transform.localScale.x)*moveSpeed, 0.0f);
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Ground"){
            FlipEnemyFacing();
        }

        
    }

    void FlipEnemyFacing(){
        transform.localScale= new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)),1f);
    }
}
