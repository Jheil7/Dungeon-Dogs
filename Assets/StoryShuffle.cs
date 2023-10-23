using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryShuffle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] TextMeshProUGUI text3;
    [SerializeField] TextMeshProUGUI text4;
    [SerializeField] TextMeshProUGUI text5;
    [SerializeField] TextMeshProUGUI text6;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StoryFadeText());
    }

    IEnumerator StoryFadeText() {
        List<TextMeshProUGUI> texts = new() {text1, text2, text3, text4, text5, text6};
        texts.ForEach(text => text.faceColor = new Color32(text.faceColor.r, text.faceColor.g, text.faceColor.b, 0));
        for(int i = 0; i < texts.Count; i++) {
            FadeTextToFullAlpha(5f, texts[i]);
            yield return new WaitForSecondsRealtime(10);
            FadeTextToZeroAlpha(5f, texts[i]);
        }
    }

    public void FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        while (i.faceColor.a < 1.0f)
        {
            Debug.Log(i.alpha);
            i.faceColor = new Color32(i.faceColor.r, i.faceColor.g, i.faceColor.b, i.faceColor.a);
        }
    }
 
    public void FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        while (i.alpha > 0.0f)
        {
            i.alpha -= Time.deltaTime / t;
        }
    }

}
