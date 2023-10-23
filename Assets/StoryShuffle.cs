using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryShuffle : MonoBehaviour
{
    [SerializeField] TMP_Text text1;
    [SerializeField] TMP_Text text2;
    [SerializeField] TMP_Text text3;
    [SerializeField] TMP_Text text4;
    [SerializeField] TMP_Text text5;
    [SerializeField] TMP_Text text6;
    [SerializeField] TMP_Text text7;
    [SerializeField] TMP_Text text8;
    [SerializeField] TMP_Text text9;
    [SerializeField] float waitTime = 8f;
    [SerializeField] Image image;

    void Start()
    {
        List<TMP_Text> texts = new() {text1, text2, text3, text4, text5, text6, text7, text8, text9};
        texts.ForEach(text => text.enabled = false);
        StartCoroutine(StoryFadeText(texts));
    }

    IEnumerator StoryFadeText(List<TMP_Text> texts) {
        for(int i = 0; i < texts.Count; i++) {
            texts[i].enabled = true;
            yield return StartCoroutine(FadeImageToZeroAlpha(image));
            image.color = new Color(0,0,0,0);
            yield return new WaitForSecondsRealtime(waitTime);
            yield return StartCoroutine(FadeImageToFullAlpha(image));
            image.color = new Color(0,0,0,1);
            texts[i].enabled = false;
        }
        SceneManager.LoadScene("Cinematic");
    }

    IEnumerator FadeImageToZeroAlpha(Image img)
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
 
    IEnumerator FadeImageToFullAlpha(Image img)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

}
