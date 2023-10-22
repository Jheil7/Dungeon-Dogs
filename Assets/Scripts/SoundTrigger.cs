using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    AudioSource audioSource;
    float randomTimer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        randomTimer=Random.Range(0f,8f);
        StartCoroutine("DelaySound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelaySound(){
        yield return new WaitForSeconds(randomTimer);
        audioSource.Play();
    }
}
