using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatforms : MonoBehaviour
{
    float rotationSpeed = 50f; 
    void Awake()
    {
        // Randomize the point's rotation to add some variety. 
        transform.Rotate(new Vector3( 0f, 0f, Random.Range(0f, 360f) ), Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the parent object on the z axis.
        // This will effectively rotate its children, the platforms. 
        transform.Rotate(new Vector3( 0f, 0f, rotationSpeed * Time.deltaTime), Space.Self); 
    }
}
