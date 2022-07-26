using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isEnded = false;

    void Awake() {
        if (!PlayerPrefs.HasKey("highScore")) {
            PlayerPrefs.SetFloat("highScore", 0f); 
        }
    }

    public void EndGame() {
        if (!isEnded) {
            isEnded = true; 
            Invoke("Restart", 2f); 
        }
    }
    public void Restart() {
        // Reload the scene. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void SetHighScore(float highScore) {
        // Check if current highScore is greater than the previous one. 
        // If it is, set it as the new value.
        if (highScore > PlayerPrefs.GetFloat("highScore")) {
            PlayerPrefs.SetFloat("highScore", highScore); 
        }
    }
    
}
