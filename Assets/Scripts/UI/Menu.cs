using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    public bool isPaused = false;
    Player player;
    PlayerRespawn playerRespawn;
    //[SerializeField] Slider slider;
    static public float volumeValue;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<Player>();
        playerRespawn=FindObjectOfType<PlayerRespawn>();
        //slider.value=volumeValue;
        //slider.value=1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(player.IsControllable);
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        //VolumeControl();
    }
    void Pause()
    {
        player.IsControllable=false;
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop the game
    }

    public void Resume()
    {
        player.IsControllable=true;
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void LoadLastCheckpoint(){
        Resume();
        playerRespawn.Respawn();
    }

    public void MainMenu(){
        Time.timeScale=1.0f;
        SceneManager.LoadScene(0);
    }

    // public void VolumeControl(){
    //     volumeValue=slider.value;
    //     AudioListener.volume=volumeValue;
    // }


}
