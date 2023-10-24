using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    Player player;
    [SerializeField ] float lightMoveSpeed;
    [SerializeField] float maxLightValue;
    [SerializeField] float lightDrainValue;
    [SerializeField] float lightDrainTimer;
    AudioSource audioClip;
    Vector3 currentPosition;
    Vector3 mousePosition;
    Vector3 worldPosition;
    public bool attachedToPlayer;
    public bool isTraveling;
    public bool recalling;
    Rigidbody2D lightRb;
    float lightValue;
    string sceneName;
    Vector3 offset;

    public bool IsRecalling{
        get{return recalling;}
        set{recalling=value;}
    }
    public float LightValue(){
        return lightValue;
    }

    public float MaxLightValue(){
        return maxLightValue;
    }

    public void SetLighttoMax(){
        lightValue=maxLightValue;
    }

    public void SetPositionToPlayer(){
        lightRb.position=player.transform.position;
        attachedToPlayer=true;
        isTraveling=false;
        recalling=false;
    }

    public void SetPositionToTalkingOffset(){
        offset=new Vector3(player.transform.position.x,player.transform.position.y+5,player.transform.position.z);
        lightRb.position=offset;
        attachedToPlayer=true;
        isTraveling=false;
        recalling=false;
    }


    void Start()
    {
        isTraveling=false;
        sceneName=SceneManager.GetActiveScene().name;
        if(!(sceneName=="Cinematic")){attachedToPlayer=true;}
        recalling=false;
        player=FindObjectOfType<Player>();
        lightRb=GetComponent<Rigidbody2D>();
        lightValue=maxLightValue;
        audioClip=GetComponent<AudioSource>();

    }

    void Update() {
        currentPosition=transform.position;
        if(isTraveling){
            MovetoPosition();
            LightTraveling();
        }
        else if(recalling){
            worldPosition=player.transform.position;
            MovetoPosition();
            LightTraveling();
        }
        else if(attachedToPlayer){
            transform.position=player.transform.position;
            isTraveling=false;
            recalling=false;

        }

    }

    void OnFire(){
        if(player.IsControllable&&!(sceneName=="Cinematic")){
            audioClip.Play();
            attachedToPlayer=false;
            mousePosition = Input.mousePosition;
            worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z=0;
            isTraveling=true;
        }


        
    }

    void OnAltFire(){
        if(player.IsControllable&&!(sceneName=="Cinematic")){
            audioClip.Play();
            recalling=true;
        }
        
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

    public void MovetoPosition(){
        lightRb.position=Vector3.MoveTowards(currentPosition,worldPosition,lightMoveSpeed);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"&&!attachedToPlayer){
            StopAllCoroutines();
            StartCoroutine("LightDrain");
            Debug.Log("go out");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            StopAllCoroutines();
        }
    }

    public IEnumerator LightDrain(){
        while(lightValue>=0){
            yield return new WaitForSeconds(lightDrainTimer);
            lightValue-=lightDrainValue;
        }

    }
}
