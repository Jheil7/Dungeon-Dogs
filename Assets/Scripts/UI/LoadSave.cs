using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSave : MonoBehaviour
{
    int levelToLoad;
    [SerializeField] GameObject loadButton;
    // Start is called before the first frame update
    void Start()
    {
        loadButton.SetActive(false);
        levelToLoad=PlayerPrefs.GetInt("levelSave");
        string levelName=PlayerPrefs.GetString("levelName");
        if(levelToLoad>0&&levelName!="Epilogue"){
            loadButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPreviousSave(){
        if(levelToLoad!=0){
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
