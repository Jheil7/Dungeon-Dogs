using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image titleSpriteOn;
    [SerializeField] Image titleSpriteOff;
    int buildIndex;

    public void Start() {
        titleSpriteOff.enabled = false;
        buildIndex=SceneManager.GetActiveScene().buildIndex;
    }
    
    public void NewGame(){
        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine() {
        titleSpriteOn.enabled = false;
        titleSpriteOff.enabled = true;
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(buildIndex+1);
    }

    public void Quit(){
        Application.Quit();
    }
}
