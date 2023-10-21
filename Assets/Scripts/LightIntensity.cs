using System.Collections;
using System.Collections.Generic;
using FunkyCode;
using FunkyCode.LightingSettings;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    LightControl lightControl;
    Light2D light2D;
    [SerializeField] float startingLightSize;
    public float lightSize;
    // Start is called before the first frame update


    void Start()
    {
        lightControl=FindAnyObjectByType<LightControl>();
        light2D=GetComponent<Light2D>();
        lightSize=startingLightSize;
    }

    // Update is called once per frame
    void Update()
    {
        light2D.size=lightSize;
        lightSize=startingLightSize*(lightControl.LightValue()/lightControl.MaxLightValue());
    }
}
