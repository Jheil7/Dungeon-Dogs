using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicBehavior : MonoBehaviour
{
    LightControl lightControl;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        lightControl=FindObjectOfType<LightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            player=other.GetComponent<Player>();
            player.IsControllable=false;
            lightControl.IsRecalling=true;
        }
    }


}
