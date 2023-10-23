using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightMeter : MonoBehaviour
{
    [SerializeField] Image lightSlider;
    LightControl lightControl;

    
    void Start()
    {
        lightControl=FindAnyObjectByType<LightControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float ratio=lightControl.LightValue()/lightControl.MaxLightValue();
        lightSlider.fillAmount=ratio;
    }


}
