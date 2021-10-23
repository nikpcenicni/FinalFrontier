using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false; 
    public GameObject pauseMenuUI;
    public GameObject deadUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
        if (GameObject.Find("Player").GetComponent<Player>().fallen){
            Dead();
        }
            
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
        GameIsPaused = false;
    }

    public void Dead() {
        deadUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame() {
        
    }
}
