using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    GameObject mainMenu;
    AudioManager audioManager; 
    void Awake() {
        mainMenu = GameObject.Find("MenuHolder").transform.GetChild(0).GetChild(2).gameObject; 
        audioManager = FindObjectOfType<AudioManager>(); 
    }

    // Switch back to the main menu. 
    public void SwitchToMenu() {
        audioManager.Play("MenuSelect"); 
        gameObject.SetActive(false); 
        mainMenu.SetActive(true); 
    }
}
