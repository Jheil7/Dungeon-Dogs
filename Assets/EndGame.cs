using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Light") && !collider.gameObject.GetComponent<LightControl>().attachedToPlayer)
        {
            // do something
            Debug.Log("you did it");
        }
    }
}
