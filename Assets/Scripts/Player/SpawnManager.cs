using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] int totalCheckpoints;
    public List<Checkpoint> checkpointList;
    Vector3 checkpointPos;

    // Start is called before the first frame update
    void Start()
    {
        List<Checkpoint> checkpointList=new List<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnCheckpoint(){

    }

    public void AddtoArray(Checkpoint checkpoint){
        checkpointList.Add(checkpoint);
    }

    public Vector2 ReturnCheckpointPosition(){
        int lastIndex=checkpointList.Count-1;
        checkpointPos=checkpointList[lastIndex].transform.position;
        return checkpointPos;

    }
}
