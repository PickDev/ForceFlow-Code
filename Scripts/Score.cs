using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Score : MonoBehaviour
{
    GameManager gameManager; 
    Transform playerTransform;
    Text score; 
    Text highScore; 

    public int currentScore; 

    void Awake() {
        currentScore = 0; 
        playerTransform = GameObject.Find("Player").transform; 
        score = gameObject.GetComponent<Text>(); 
        highScore = GameObject.Find("HighScore").GetComponent<Text>();  
        gameManager = FindObjectOfType<GameManager>(); 
    }
    void Update() {
        // Set the score text to the player's position on the z-axis rounded to the nearest whole number. 
        // I decided to divide the z position by 10 to make the player earn their points. 
        // Acquiring too many points too early into the game doesn't feel fun. 
        currentScore = (int) (playerTransform.position.z / 10f); 
        score.text = currentScore.ToString(); 
        gameManager.SetHighScore(currentScore); 
        highScore.text = "HIGHSCORE - " + PlayerPrefs.GetFloat("highScore", 0f); 
    }
}
