using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool isShaking; 

    // This method shakes the camera by randomizing its rotation
    // Every frame until the duration is up. The randomness of the 
    // Euler angles generated is determined by the magnitude. 
    // After the camera shake is finished, the camera's rotation is 
    // reset to Quaternion.identity, or simply zero. 
    public IEnumerator Shake (float duration, float magnitude) {
        Vector3 originalPos = transform.position; 

        float elapsed = 0.0f; 
        while (elapsed <= duration) {
            // Generate three random points. 
            float x = Random.Range(-1f, 1f) * magnitude; 
            float y = Random.Range(-1f, 1f) * magnitude; 
            float z = Random.Range(-1f, 1f) * magnitude;

            // Set the shake rotation to the randomly generated euler angle. 
            Quaternion shakeRot = Quaternion.Euler(x, y, z); 
            // Set the local rotation of the camera to the shake rotation. 
            transform.localRotation = shakeRot; 
            // Increase elapsed time. 
            elapsed += Time.deltaTime; 

            yield return null; 
        }

        transform.localRotation = Quaternion.identity; 
        // Reset local rotation to zero. Note that localRotation
        // Refers to the rotation of the camera with respect to its 
        // Parent. If you look in the inspector, you can see that the 
        // CamHolder's rotation never changes. This is because we want to keep
        // That general rotation throughout the game. 
    }
}
