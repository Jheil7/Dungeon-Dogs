using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndStoryShuffle : MonoBehaviour
{
    [SerializeField] TMP_Text text1;
    [SerializeField] Image image1;
    [SerializeField] float waitTime = 8f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] Image backgroundImage;

    void Start()
    {
        StartCoroutine(StoryFadeText());
    }

    IEnumerator StoryFadeText() {
        text1.enabled = true;
        image1.enabled = true;
        yield return StartCoroutine(FadeImageToZeroAlpha(backgroundImage));
        backgroundImage.color = new Color(0,0,0,0);
        yield return new WaitForSecondsRealtime(waitTime);
        yield return StartCoroutine(FadeImageToFullAlpha(backgroundImage));
        backgroundImage.color = new Color(0,0,0,1);
        image1.enabled = false;
        text1.enabled = false;
        SceneManager.LoadScene(0);
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
