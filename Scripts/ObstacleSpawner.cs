using System.Collections;
using System.Collections.Generic;
using System; 
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;
    Vector3 obstacle0 = new Vector3(0f, 0f, 46f); 
    Vector3 obstacle1 = new Vector3(0f, 0f, 92f);
    GameObject firstObstacle, secondObstacle; 
    GroundSpawner groundSpawner; 
    
    void Start() {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Note: instantiated obstacles are assigned as children to the Ground prefab from GroundSpawner
    // Because that will ensure that they get deleted with the ground (see ProceduralSpawner.cs). 
    public void SpawnObstacles() {
        // Instantiate first obstacle and assign parent as instantiated Ground prefab from GroundSpawner.cs.
        firstObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Count)], obstacle0, Quaternion.identity, groundSpawner.temp.transform); 
        obstacle0 = groundSpawner.temp.transform.GetChild(2).transform.position; 

        // Instantiate second obstacle and assign parent as instantiated Ground prefab from GroundSpawner.cs.
        secondObstacle = Instantiate(obstacles[UnityEngine.Random.Range(0,4)], obstacle1, Quaternion.identity, groundSpawner.temp.transform); 
        obstacle1 = groundSpawner.temp.transform.GetChild(3).transform.position;   
        
        ModifyObstacle(firstObstacle); 
        ModifyObstacle(secondObstacle); 
    }

    // This chunky method takes care of all of the translational and rotational offsets. 
    public void ModifyObstacle(GameObject obstacle) {
        Vector3 pos = obstacle.transform.position; 

        if (obstacle.name.Contains("Beam1")) {
            int flip = UnityEngine.Random.Range(0, 2);
            // Move the beam 1.5 units up. 
            obstacle.transform.position = new Vector3(0f, 1.5f, pos.z); 
            // Flip the beam either right or left. This exludes the need for two separate models. 
            if (flip == 0) {
                obstacle.transform.Rotate(0f, 90f, 0f); 
            } else if (flip == 1) {
                obstacle.transform.Rotate(0f, -90f, 0f);
            }
        } else if (obstacle.name.Contains("Beam2") || obstacle.name.Contains("Beam3")) {
            // Move the beam 1.5 units up. 
            obstacle.transform.position = new Vector3(0f, 1.5f, pos.z); 
            obstacle.transform.Rotate(0f, 90f, 0f); 
        } else if (obstacle.name.Contains("Wall")) {  
            int flip = UnityEngine.Random.Range(0, 2);
            // Move the wall 5.5 units up. 
            obstacle.transform.position = new Vector3(0f, 5.5f, pos.z);
            obstacle.transform.Rotate(0f, 90f, 0f);
            // Rotate the wall either left or right. 
            if (flip == 1) {
                obstacle.transform.localScale = new Vector3(1f, 1f, -1f); 
            }
            obstacle.transform.GetChild(0).tag = "Obstacle"; 
            return; // Return because only the main wall needs to be tagged as Obstacle. 
        } else if (obstacle.name.Contains("VerticalSpinner")) {
            obstacle.transform.Rotate(0f, 90f, 0f);
            obstacle.transform.position = new Vector3(pos.x, 3f, pos.z); 
        } else if (obstacle.name.Contains("HorizontalSpinner")) {
            obstacle.transform.Rotate(0f, 90f, 0f); 
            obstacle.transform.position = new Vector3(pos.x, 1.5f, pos.z);
        }
        // Set the tag of the instantiated prefab to Obstacle.
        obstacle.tag = "Obstacle"; 
    }
}
