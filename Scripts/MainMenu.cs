using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    GameObject optionsMenu, creditsMenu; 
    AudioManager audioManager; 
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>(); 
        // Because the OptionsMenu object is inactive when the MainMenu object is active,
        // a regular FindObjectOfType<>() won't work here. Instead, I assigned all menu 
        // objects to an empty parent, and accessed the children of that parent. 
        // The first child is the canvas, and the canvas's fourth child is the OptionsMenu object. 
        optionsMenu = GameObject.Find("MenuHolder").transform.GetChild(0).GetChild(3).gameObject; 
        creditsMenu = GameObject.Find("MenuHolder").transform.GetChild(0).GetChild(1).gameObject; 
    }

    public void PlayGame() {
        // Load next scene in the queue. 
        audioManager.Play("MenuSelect"); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void SwitchToOptions() {
        // Play menu select sound and switch "scenes". 
        audioManager.Play("MenuSelect"); 
        gameObject.SetActive(false); 
        optionsMenu.SetActive(true); 
    }

    public void SwitchToCredits() {
        // Play menu select sound and switch "scenes". 
        audioManager.Play("MenuSelect"); 
        gameObject.SetActive(false); 
        creditsMenu.SetActive(true); 
    }

    public void Quit() {
        // Close the game.
        audioManager.Play("MenuSelect");  
        Application.Quit();
    }
}
