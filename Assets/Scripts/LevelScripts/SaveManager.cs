using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex=SceneManager.GetActiveScene().buildIndex;
        string sceneString=SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("levelSave",sceneIndex);
        PlayerPrefs.SetString("levelName", sceneString);
        Debug.Log(sceneString);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void SaveLevel(){
    //     PlayerPrefs.SetInt("levelSave",sceneIndex);
    // }

    void GetLevel(){
        int loadedLevel=PlayerPrefs.GetInt("levelSave");
        SceneManager.LoadScene(loadedLevel);
    }

}
