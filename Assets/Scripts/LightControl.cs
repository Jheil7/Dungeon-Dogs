using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    Player player;
    bool attachedToPlayer;
    [SerializeField ] float lightMoveSpeed;
    Vector3 currentPosition;
    Vector3 mousePosition;
    Vector3 worldPosition;
    bool isTraveling;
    bool recalling;
    Rigidbody2D lightRb;
    LightMeter lightMeter;
    [SerializeField] float maxLightValue;
    [SerializeField] float lightDrainValue;
    float lightValue;
    [SerializeField] float lightDrainTimer;

    public float LightValue(){
        return lightValue;
    }

    public float MaxLightValue(){
        return maxLightValue;
    }


    void Start()
    {
        isTraveling=false;
        attachedToPlayer=true;
        recalling=false;
        player=FindObjectOfType<Player>();
        lightRb=GetComponent<Rigidbody2D>();
        lightMeter=FindAnyObjectByType<LightMeter>();
        lightValue=maxLightValue;

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition=transform.position;
        if(isTraveling){
            MovetoPosition();
            LightTraveling();
        }
        if(recalling){
            worldPosition=player.transform.position;
            MovetoPosition();
            LightTraveling();
        }
        if(attachedToPlayer){
            transform.position=player.transform.position;
            isTraveling=false;
            recalling=false;
        }
    }

    void FixedUpdate() {


    }

    void OnFire(){
        attachedToPlayer=false;
        mousePosition = Input.mousePosition;
        worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z=0;
        isTraveling=true;

        
    }

    void OnAltFire(){
        recalling=true;
    }

    void LightTraveling(){
        if(Vector3.Distance(currentPosition,worldPosition)<=1){
            lightRb.velocity=new Vector3(0,0,0);
            isTraveling=false;
            recalling=false;
            if(Vector3.Distance(worldPosition,player.transform.position)<=1){
                attachedToPlayer=true;
            }
        }
    }

    void MovetoPosition(){
        lightRb.position=Vector3.MoveTowards(currentPosition,worldPosition,lightMoveSpeed);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
            StartCoroutine("LightDrain");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            StopCoroutine("LightDrain");
        }
    }

    public IEnumerator LightDrain(){
        while(lightValue>=0){
            yield return new WaitForSeconds(lightDrainTimer);
            lightValue-=lightDrainValue;
        }

    }
}
