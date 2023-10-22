using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRun : MonoBehaviour
{
    [SerializeField] GameObject startingObject;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos=startingObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            other.transform.position=startPos;
        }
    }
}
