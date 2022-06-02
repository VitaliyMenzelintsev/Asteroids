using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour
{
    private Rigidbody2D starshipRigidbody;
    //private Transform playerPosition;

    private float verticalInput;           // thrustInput
    private float horizontalInput;         // turnInput
    public float velocity;                 // thrust
    public float angulaVelocity;           // turnThrust

    public float screenTopBorder = 8.6f;
    public float screenBottomBorder = -8.6f;
    public float screenRightBorder = 14.5f;
    public float screenLeftBorder = -14.5f;

    void Start()
    {
        starshipRigidbody = gameObject.GetComponent<Rigidbody2D>();
        //playerPosition = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        // Input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Screen 
        Vector2 newPosition = transform.position;

        if (transform.position.y > screenTopBorder) newPosition.y = screenBottomBorder;
       
        if (transform.position.y < screenBottomBorder) newPosition.y = screenTopBorder;
        
        if (transform.position.x > screenRightBorder) newPosition.x = screenLeftBorder;
        

        if (transform.position.x < screenLeftBorder) newPosition.x = screenRightBorder;
       
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        starshipRigidbody.AddRelativeForce(Vector2.up * verticalInput * velocity);
        starshipRigidbody.AddTorque(-horizontalInput * angulaVelocity);
    }
}
