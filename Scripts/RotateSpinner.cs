using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpinner : MonoBehaviour
{
    float rotationSpeed = 300f; 
    // Update is called once per frame
    void Update()
    {
        // Rotate vertical spinner about the z axis. 
        if (this.name.Contains("Vertical")) {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        } else if (this.name.Contains("Horizontal")) {
            // Rotate the horizontal spinner about the x axis. 
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
