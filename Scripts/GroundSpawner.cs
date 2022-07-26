using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject plane; 
    public GameObject temp; 
    Vector3 NextSpawnPoint;  
    
    void Start()
    {
        // Spawn in initial ground planes. 
        for (int i = 0; i < 3; i++) {
            SpawnGround(); 
        }
    }

    public void SpawnGround() {
        // Instantiate the ground prefab at the spawnpoint.
        // Then, shift the spawnpoint's position. 
        temp = Instantiate(plane, NextSpawnPoint, Quaternion.identity); 
        NextSpawnPoint = temp.transform.GetChild(1).transform.position; 
    }
}
