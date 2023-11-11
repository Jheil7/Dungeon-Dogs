using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFade : MonoBehaviour
{
    AudioSource audioSource;
    float startVolume;
    float fadeTime=2.0f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        startVolume=audioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeAudio(){
        audioSource.volume=Mathf.Lerp(startVolume,startVolume-(startVolume/10),fadeTime);
    }
}
