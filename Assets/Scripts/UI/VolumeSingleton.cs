using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSingleton : MonoBehaviour
{
    static public float volumeValue;
    [SerializeField] Slider slider;
    private const string FirstTimeKey = "FirstTime";
    private const string VolumeKey = "Volume";
     
    void Awake()
    {   
        volumeValue=PlayerPrefs.GetFloat("masterVolume",0.5f);
        slider.value=volumeValue;
    }

    private void Update() {
        VolumeControl();
    }

    public void VolumeControl(){
        volumeValue=slider.value;
        PlayerPrefs.SetFloat("masterVolume",volumeValue);
        AudioListener.volume=volumeValue;
    }

}
