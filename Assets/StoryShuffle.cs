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
    [SerializeField] Image image1;
    [SerializeField] TMP_Text text2;
    [SerializeField] Image image2;
    [SerializeField] TMP_Text text3;
    [SerializeField] Image image3;
    [SerializeField] TMP_Text text4;
    [SerializeField] Image image4;
    [SerializeField] TMP_Text text5;
    [SerializeField] Image image5;
    [SerializeField] TMP_Text text6;
    [SerializeField] Image image6;
    [SerializeField] TMP_Text text7;
    [SerializeField] Image image7;
    [SerializeField] TMP_Text text8;
    [SerializeField] Image image8;
    [SerializeField] TMP_Text text9;
    [SerializeField] Image image9;
    [SerializeField] float waitTime = 8f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] Image backgroundImage;

    void Start()
    {
        List<TMP_Text> texts = new() {text1, text2, text3, text4, text5, text6, text7, text8, text9};
        List<Image> images = new() {image1, image2, image3, image4, image5, image6, image7, image8, image9};
        texts.ForEach(text => text.enabled = false);
        images.ForEach(image => image.enabled = false);
        StartCoroutine(StoryFadeText(texts, images));
    }

    IEnumerator StoryFadeText(List<TMP_Text> texts, List<Image> images) {
        for(int i = 0; i < texts.Count; i++) {
            texts[i].enabled = true;
            images[i].enabled = true;
            yield return StartCoroutine(FadeImageToZeroAlpha(backgroundImage));
            backgroundImage.color = new Color(0,0,0,0);
            yield return new WaitForSecondsRealtime(waitTime);
            yield return StartCoroutine(FadeImageToFullAlpha(backgroundImage));
            backgroundImage.color = new Color(0,0,0,1);
            images[i].enabled = false;
            texts[i].enabled = false;
        }
        SceneManager.LoadScene("Cinematic");
    }

    IEnumerator FadeImageToZeroAlpha(Image img)
    {
        for (float i = fadeTime; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
 
    IEnumerator FadeImageToFullAlpha(Image img)
    {
        for (float i = 0; i <= fadeTime; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

}
