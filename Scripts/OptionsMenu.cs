using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI; 

public class OptionsMenu : MonoBehaviour
{
    GameObject mainMenu;
    AudioManager audioManager; 
    Resolution[] resolutions; 
    public AudioMixer audioMixer; 
    Dropdown resolutionDropdown; 

    public void Awake() {
        mainMenu = GameObject.Find("MenuHolder").transform.GetChild(0).GetChild(2).gameObject; 
        audioManager = FindObjectOfType<AudioManager>(); 
        // Reference the resolution dropdown (should be 8th child of OptionsMenu)
        resolutionDropdown = gameObject.transform.GetChild(7).GetComponent<Dropdown>();
        resolutionDropdown.ClearOptions(); 

        // Populate resolutions list with screen resolutions. 
        resolutions = Screen.resolutions; 

        // Make a list of type string to hold the dropdown options. 
        List<string> options = new List<string>();

        int currentResIndex = 0; 
        
        // Populate the options list. 
        foreach (Resolution res in resolutions) {
            if (res.width / res.height <= 1.78) {
                string option = res.width + " x " + res.height + " @ " + res.refreshRate + "hz"; 
                options.Add(option); 
            }

            if (res.width == Screen.width && res.height == Screen.height) {
                currentResIndex = Array.IndexOf(resolutions, res); 
            }
        }
        // Add the options list to the resolutions dropdown. 
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex; 
        // Refresh dropdown to update values. 
        resolutionDropdown.RefreshShownValue();
    }

    // Sets the resolution of the screen to the element at resolutionIndex in the resolutions arr. 
    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex]; 
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
    }

    // Sets the volume of the master channel in the AudioMixer. 
    public void SetVolume(float volume) {
        // Volume variables work like dictionaries/player prefabs as well. 
        audioMixer.SetFloat("masterVolume", volume); 
    }
    
    // Sets full screen to isFullScreen. 
    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen; 
    }

    // Plays the menu select sound and switches scenes. 
    public void SwitchToMenu() {
        audioManager.Play("MenuSelect"); 
        gameObject.SetActive(false); 
        mainMenu.SetActive(true); 
    }
}
