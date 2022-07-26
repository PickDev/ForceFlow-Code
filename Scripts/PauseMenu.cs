using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; 
    GameObject pauseMenu; 
    AudioManager audioManager; 

    void Awake() {
        pauseMenu = gameObject.transform.GetChild(0).gameObject; 
        audioManager = FindObjectOfType<AudioManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Pause/un-pause menu from input.  
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused == true) {
                Resume(); 
            } else {
                Pause(); 
            }
        }
    }

    // Resume the game by setting timeScale back to one. 
    public void Resume() {
        audioManager.Play("MenuSelect"); 
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
        gameIsPaused = false;
    }

    // Set timeScale to zero to pause the game. 
    void Pause() {
        audioManager.Play("MenuSelect"); 
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
        gameIsPaused = true; 
    }

    // Load the main menu scene by its build index. 
    public void LoadMenu() {
        audioManager.Play("MenuSelect"); 
        SceneManager.LoadScene(0); 
        Resume(); 
    }

    // Quit the game 
    public void Quit() {
        audioManager.Play("MenuSelect"); 
        Application.Quit(); 
    }
}
