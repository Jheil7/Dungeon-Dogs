using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    SpawnManager spawnManager;
    Animator animator;
    LightControl lightControl;
    [SerializeField] float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager=FindObjectOfType<SpawnManager>();
        animator=GetComponent<Animator>();
        lightControl=FindObjectOfType<LightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){
            Debug.Log("Player Dead");
            animator.SetBool("Dead", true);
        }
    }

            
    


    public void Respawn(){
        transform.position=spawnManager.ReturnCheckpointPosition();
        lightControl.SetLighttoMax();
        lightControl.SetPositionToPlayer();
        animator.SetBool("Dead", false);
    }
}
