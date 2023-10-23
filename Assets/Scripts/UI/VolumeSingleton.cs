using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSingleton : MonoBehaviour
{
    static public float volumeValue;
    [SerializeField] Slider slider;
     
    void Awake()
    {   
        string sceneIndex=SceneManager.GetActiveScene().name;
        if(sceneIndex=="MainMenu"){volumeValue=0.5f;}
        slider.value=volumeValue;
    }

    private void Update() {
        VolumeControl();
    }

    public void VolumeControl(){
        volumeValue=slider.value;
        AudioListener.volume=volumeValue;
    }

}
