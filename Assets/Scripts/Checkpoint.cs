using System.Collections;
using System.Collections.Generic;
using FunkyCode;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    SpawnManager spawnManager;
    Light2D lanternLight;
    bool checkpointActive;
    int glowSize=10;


    // Start is called before the first frame update
    void Start()
    {
        checkpointActive=false;
        spawnManager=FindObjectOfType<SpawnManager>();
        lanternLight=GetComponentInChildren<Light2D>();
        lanternLight.size=0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&checkpointActive==false){
            spawnManager.AddtoArray(this);
            lanternLight.size=glowSize;
            checkpointActive=true;            
        }
    }

    public Vector2 MarkCheckpoint(){
        return this.transform.position;
    }
}
