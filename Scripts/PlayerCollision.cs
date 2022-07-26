using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerCollision : MonoBehaviour
{
   PlayerMovement movement; 
   CameraShake cameraShake; 
   AudioManager audioManager; 
   Rigidbody rb; 
   public GameObject fractured;
   public float shatterForce = 1500f; 
   Score score;

    void Start() {
        movement = FindObjectOfType<PlayerMovement>(); 
        cameraShake = FindObjectOfType<CameraShake>(); 
        audioManager = FindObjectOfType<AudioManager>();
        score = GameObject.Find("Score").GetComponent<Score>(); 
        rb = GameObject.Find("Player").GetComponent<Rigidbody>(); 
        fractured = (GameObject) Resources.Load("Prefabs/General/FracturedPlayer", typeof(GameObject));  
    }

    void OnCollisionEnter(Collision collision) {
        // Check if the collider's tag is set to Obstacle
        // If it is indeed an obstacle, end the game. 
        if (collision.collider.tag == "Obstacle" || rb.velocity.z == 0f) {  
            // Check if the last instance was deleted at (AudioManager line 24)
            if (audioManager == null) {
                // If it was, refer to the new AudioManager. 
                audioManager = FindObjectOfType<AudioManager>();
            }
            audioManager.Play("PlayerDeath"); 
            Shatter();  
            score.enabled = false;
            FindObjectOfType<GameManager>().EndGame(); 
        }
    }

    // This method instantiates the FracturedPlayer prefab and adds a force to each one of its children. 
    // The original player is destroyed. 
    public void Shatter() {
        Destroy(gameObject);
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>()) {
            Vector3 force = (rb.transform.position - transform.position).normalized * shatterForce; 
            rb.AddForce(force); 
        } 
    }
}
