using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    SpawnManager spawnManager;
    Animator animator;
    LightControl lightControl;
    Player player;
    [SerializeField] float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager=FindObjectOfType<SpawnManager>();
        animator=GetComponentInChildren<Animator>();
        lightControl=FindObjectOfType<LightControl>();
        player=GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){
            animator.SetBool("dead", true);
        }
    }
    public void Respawn(){
        animator.SetBool("dead", false);
        transform.position=spawnManager.ReturnCheckpointPosition();
        lightControl.SetLighttoMax();
        lightControl.SetPositionToPlayer();
    }
}
