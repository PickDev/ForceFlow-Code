using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player; 
    Transform fracturedPlayer; 
    float smoothTime = 0.04f; 
    Vector3 velocity = Vector3.zero; 
    Vector3 offset; 
    CameraShake cameraShake; 

   [Header("Camera Shake")]
   public float duration = 0.08f; 
   public float magnitude = 1.2f;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>(); 
        offset = new Vector3(0, 3, -7); 
        cameraShake = FindObjectOfType<CameraShake>(); 
    } 
    
    void Update() {
        try {
            // Set the position of the camera to the player's position with an offset. 
            // SmoothDamp allows this to be done smoothly. 
            Vector3 targetPos = player.position + offset; 
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime); 
        } catch { 
            // When the player gets deleted, we'll get a null reference exception
            // In this case, run the camera shake and turn off this script after it's finished. 
            StartCoroutine(cameraShake.Shake(duration, magnitude));
            this.enabled = false; 
        }
    }
}
