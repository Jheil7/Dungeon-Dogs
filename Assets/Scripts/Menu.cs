using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    public bool isPaused = false;
    Player player;
    PlayerRespawn playerRespawn;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<Player>();
        playerRespawn=FindObjectOfType<PlayerRespawn>();
        slider.value=1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                player.IsControllable=true;
            }
            else
            {
                Pause();
                player.IsControllable=false;
            }
        }
        VolumeControl();
    }
    void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Stop the game
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

    public void LoadLastCheckpoint(){
        Resume();
        playerRespawn.Respawn();
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void VolumeControl(){
        AudioListener.volume=slider.value;
    }


}
