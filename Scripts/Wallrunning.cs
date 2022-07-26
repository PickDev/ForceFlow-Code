using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning : MonoBehaviour
{
    // References 
    Rigidbody rb; 
    PlayerMovement pm; 

    [Header("Wall Detection")]
    bool wallLeft, wallRight;
    [SerializeField] float minDistance = 0.03f;  
    RaycastHit leftHit, rightHit; 
    
    [Header("Wall Movement")]
    [SerializeField] float wallGravity = 30f; 
    [SerializeField] float wallJumpForce = 3000f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        pm = GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkWall(); 

        if (wallLeft || wallRight) {
            startWallRun(); 
        } else {
            stopWallRun(); 
        }   
    }

    // This checks if a wall is nearby. 
    void checkWall() {
        // Don't check for wall when player hits the jump key for the first time.  
        if (!Input.GetKey(KeyCode.Space)) {
            wallLeft = Physics.Raycast(rb.transform.position, Vector3.left, out leftHit, minDistance);
            wallRight = Physics.Raycast(rb.transform.position, Vector3.right, out rightHit, minDistance);
        }
    }

    // This method starts the wallrun by replacing normal gravity with a custom one. 
    void startWallRun() {
        rb.useGravity = false;

        rb.AddForce(Vector3.down * wallGravity, ForceMode.Force);

        wallJump(); 
    }

    // Re-enable normal gravity. 
    void stopWallRun() {
        rb.useGravity = true; 
    }

    // This method checks if the player presses space when wallrunning. 
    // If they do, apply a force in the diagonal direction of the wall's normal + up. 
    void wallJump() {
        if (Input.GetKey(KeyCode.Space)) {
            if (wallLeft) {
                // Get the hypotenuse of the normal + up. 
                Vector3 wallJumpDirection = leftHit.normal + rb.transform.up; 
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
                rb.AddForce(wallJumpDirection * wallJumpForce, ForceMode.Impulse); 
                wallLeft = false; 
            } else if (wallRight) {
                // Get the hypotenuse of the normal + up. 
                Vector3 wallJumpDirection = rightHit.normal + rb.transform.up; 
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
                rb.AddForce(wallJumpDirection * wallJumpForce, ForceMode.Impulse);
                wallRight = false; 
            }
        }
    }

}
