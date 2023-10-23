using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    Player player;
    public bool attachedToPlayer;
    [SerializeField ] float lightMoveSpeed;
    Vector3 currentPosition;
    Vector3 mousePosition;
    Vector3 worldPosition;
    public bool isTraveling;
    public bool recalling;
    Rigidbody2D lightRb;
    [SerializeField] float maxLightValue;
    [SerializeField] float lightDrainValue;
    float lightValue;
    [SerializeField] float lightDrainTimer;
    SpriteRenderer spriteRenderer;
    int sceneIndex;

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
        Vector3 offset=new Vector3(player.transform.position.x,player.transform.position.y+5,player.transform.position.z);
        lightRb.position=offset;
        attachedToPlayer=true;
        isTraveling=false;
        recalling=false;
    }


    void Start()
    {
        isTraveling=false;
        sceneIndex=SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex>1){attachedToPlayer=true;}
        recalling=false;
        player=FindObjectOfType<Player>();
        lightRb=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        lightValue=maxLightValue;

    }

    // Update is called once per frame

    void Update() {
        currentPosition=transform.position;
        if(isTraveling){
            MovetoPosition(worldPosition);
            LightTraveling();
        }
        else if(recalling){
            worldPosition=player.transform.position;
            MovetoPosition(worldPosition);
            LightTraveling();
        }
        else if(attachedToPlayer){
            transform.position=player.transform.position;
            //Debug.Log(transform.position);
            isTraveling=false;
            recalling=false;
            spriteRenderer.enabled = false;
        }

    }

    void OnFire(){
        if(player.IsControllable&&sceneIndex>1){
            attachedToPlayer=false;
            mousePosition = Input.mousePosition;
            worldPosition=Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z=0;
            isTraveling=true;
            if(!spriteRenderer.enabled){
                spriteRenderer.enabled = true;
            }
        }


        
    }

    void OnAltFire(){
        if(player.IsControllable&&sceneIndex>1){
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

    public void MovetoPosition(Vector3 movePos){
        lightRb.position=Vector3.MoveTowards(currentPosition,movePos,lightMoveSpeed);
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
            Debug.Log("come back");
        }
    }

    public IEnumerator LightDrain(){
        while(lightValue>=0){
            yield return new WaitForSeconds(lightDrainTimer);
            lightValue-=lightDrainValue;
        }

    }
}
