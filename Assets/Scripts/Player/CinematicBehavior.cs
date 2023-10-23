using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBehavior : MonoBehaviour
{
    LightControl lightControl;
    Player player;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        lightControl=FindObjectOfType<LightControl>();
        boxCollider=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            player=other.GetComponent<Player>();
            lightControl.IsRecalling=true;
            boxCollider.enabled=false;

        }
    }


}
