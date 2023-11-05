using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    public void PlayFootstep(){
        audioSource.pitch=Random.Range(0.8f,1f);
        audioSource.clip=audioClips[0];
        audioSource.Play();
    }

    public void PlayDeathSound(){
        audioSource.clip=audioClips[1];
        audioSource.Play();
    }

    public void JumpSound(){
        audioSource.clip=audioClips[2];
        audioSource.Play();
    }
}
