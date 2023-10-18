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
    Rigidbody2D lightRb;
    // Start is called before the first frame update
    void Start()
    {
        isTraveling=true;
        attachedToPlayer=true;
        player=FindObjectOfType<Player>();
        lightRb=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition=transform.position;
        if(isTraveling){
            lightRb.position=Vector3.MoveTowards(currentPosition,worldPosition,lightMoveSpeed);
            LightTraveling();
        }
        
    }

    void FixedUpdate() {

        if(attachedToPlayer){
            transform.position=player.transform.position;
        }

    }

    void OnFire(){
        attachedToPlayer=false;
        mousePosition = Input.mousePosition;
        worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z=0;
        isTraveling=true;
        
        //transform.position=worldPosition;
    }

    void LightTraveling(){
        Debug.Log(lightRb.velocity);
        //Debug.Log(Vector3.Distance(currentPosition,worldPosition));
        if(Vector3.Distance(currentPosition,worldPosition)<=1){
            lightRb.velocity=new Vector3(0,0,0);
            isTraveling=false;
        }

    }

    IEnumerator TravelCheck(){
        yield return new WaitForSeconds(2);
    }
}
