using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralSpawner : MonoBehaviour
{
    GroundSpawner groundSpawner; 
    ObstacleSpawner obstacleSpawner; 

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>(); 
        obstacleSpawner = GameObject.FindObjectOfType<ObstacleSpawner>(); 
    }

    // As player exits the box collider of the ground prefab (the collider is marked as a trigger
    // and this method is like an event listener for triggers), more ground and obstacles are
    // instantiated, and the GameObject (ground) tied to the collider is deleted. Since the
    // instantiated obstacles on that ground are its children, they get deleted too. 
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") { 
            groundSpawner.SpawnGround();  
            obstacleSpawner.SpawnObstacles(); 
            Destroy(gameObject, 3f); 
        }
    }
}
