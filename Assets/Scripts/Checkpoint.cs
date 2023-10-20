using System.Collections;
using System.Collections.Generic;
using FunkyCode;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector2[] checkpointPos;
    SpawnManager spawnManager;
    Light2D lanternLight;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager=FindObjectOfType<SpawnManager>();
        lanternLight=GetComponentInChildren<Light2D>();
        checkpointPos=new Vector2[3];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            
            lanternLight.gameObject.SetActive(true);
            Debug.Log("asdfa");
            
        }
    }

    void MarkCheckpoint(){

    }
}
