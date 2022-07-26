using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Inspector 
    [Header("References")]
    Rigidbody rb; 
    Score score; 
    [Header("Movement & Ground Detection")]
    public float jumpForce = 100f; 
    public float sideForce = 150f; 
    public float forwardForce = 600f; 

    public float groundDistance = 0.1f; 
    public Vector3 playerHeight = new Vector3(0, 1, 0); 
    public LayerMask groundMask; 
    [Header("Drag")]
    public float groundDrag = 3f; 
    public float airDrag = 6f; 

    // Private 
    bool isGrounded;
    float horizontalSpeed;  

    void Start() {
        // Define references 
        rb = GetComponent<Rigidbody>(); 
        score = GameObject.Find("Score").GetComponent<Score>(); 
        rb.constraints = RigidbodyConstraints.FreezeRotation;  
    }
    void FixedUpdate() {
        // Check if the player is grounded using a sphere. 
        isGrounded = checkGround(); 

        //forwardForce = Mathf.Lerp(initialForce, finalForce, 500f);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        
        // Call input and limit drag. 
        MyInput(); 
        ControlDrag(); 
        
        // If player is below minimum y, end the game. 
        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame(); 
            rb.constraints = RigidbodyConstraints.None; 
            score.enabled = false; 
        }

        // Jump only if space is pressed and the player is grounded. 
        if (Input.GetKey("space") && isGrounded) {
            Jump(); 
        }

        if (rb.velocity.y < 0f) {
            rb.AddForce(Vector3.down * 100f, ForceMode.Acceleration);  
        } 

    }

    // Horizontal input. 
    void MyInput() {
        horizontalSpeed = sideForce * Input.GetAxisRaw("Horizontal"); 
        rb.AddForce(horizontalSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    // Change drag depending on state. 
    public void ControlDrag() {
        if (isGrounded) {
            rb.drag = groundDrag;
        } else {
            rb.drag = airDrag;  
        }
    }

    // Add a vertical force to the player for jumping. 
    void Jump() {
        rb.AddForce(rb.transform.up * jumpForce, ForceMode.Impulse);
    }

    // Checks if the player is currently grounded. 
    public bool checkGround() {
        return Physics.CheckSphere(transform.position - playerHeight, groundDistance, groundMask); 
    }
}
