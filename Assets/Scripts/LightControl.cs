using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightControl : MonoBehaviour
{
    Player player;
    bool attachedToPlayer;
    [SerializeField ] float lightMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        attachedToPlayer=true;
        player=FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(attachedToPlayer){
            transform.position=player.transform.position;
        }
    }

    void OnFire(){
        attachedToPlayer=false;
        Vector3 currentPosition=transform.position;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z=0;
        Vector3 worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
        
        transform.position=worldPosition;
    }
}
