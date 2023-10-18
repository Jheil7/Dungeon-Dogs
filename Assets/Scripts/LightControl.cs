using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightControl : MonoBehaviour
{
    Player player;
    bool attachedToPlayer;
    [SerializeField ] float lightMoveSpeed;
    Vector3 currentPosition;
    Vector3 mousePosition;
    Vector3 worldPosition;
    bool isTraveling;
    // Start is called before the first frame update
    void Start()
    {
        isTraveling=true;
        attachedToPlayer=true;
        player=FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        LightTraveling();
        if(attachedToPlayer){
            transform.position=player.transform.position;
        }

    }

    void OnFire(){
        attachedToPlayer=false;
        currentPosition=transform.position;
        mousePosition = Input.mousePosition;
        mousePosition.z=0;
        worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
        
        //transform.position=worldPosition;
    }

    void LightTraveling(){
        if(Vector3.Distance(currentPosition,worldPosition)<=1){
            isTraveling=false;
        }
        if(isTraveling){
            transform.position=Vector3.MoveTowards(currentPosition,worldPosition,lightMoveSpeed);
        }
    }
}
