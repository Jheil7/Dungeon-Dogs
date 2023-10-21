using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    SpawnManager spawnManager;
    Animator animator;
    LightControl lightControl;
    [SerializeField] float respawnTime;
    bool respawnQueued;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager=FindObjectOfType<SpawnManager>();
        animator=GetComponent<Animator>();
        lightControl=FindObjectOfType<LightControl>();
        respawnQueued=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){
            Debug.Log("Player Dead");
            animator.SetBool("Dead", true);
            StartCoroutine("RespawnWait");
        }
    }

    IEnumerator RespawnWait(){
        if(!respawnQueued){
            respawnQueued=true;
            yield return new WaitForSeconds(respawnTime);
            animator.SetBool("Dead", false);
            transform.position=spawnManager.ReturnCheckpointPosition();
            lightControl.SetLighttoMax();
            lightControl.SetPositionToPlayer();
            respawnQueued=false;

        }

    }
}
