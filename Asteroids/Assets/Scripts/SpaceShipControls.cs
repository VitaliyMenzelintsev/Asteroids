using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour
{
    public Bullet bullet;
    private Rigidbody2D starshipRigidbody;
    
    // Характеристики корабля
    private float verticalInput;           // thrustInput
    private float horizontalInput;         // turnInput
    private float velocity = 4;                 // thrust
    private float angulaVelocity = 3;           // turnThrust

    // Размеры экрана
    private float screenTopBorder = 8.6f;
    private float screenBottomBorder = -8.6f;
    private float screenRightBorder = 14.5f;
    private float screenLeftBorder = -14.5f;

    // Стрельба
    public Transform[] projectileSpawnPoint;
    private float nextShotTime;
    private float betweenShots = 0.2f;


    private void Start()
    {
        starshipRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Вылет за пределы экрана
        Vector2 newPosition = transform.position;

        if (transform.position.y > screenTopBorder) newPosition.y = screenBottomBorder;

        if (transform.position.y < screenBottomBorder) newPosition.y = screenTopBorder;

        if (transform.position.x > screenRightBorder) newPosition.x = screenLeftBorder;

        if (transform.position.x < screenLeftBorder) newPosition.x = screenRightBorder;

        transform.position = newPosition;

        // Стрельба
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

        for (int i = 0; i < projectileSpawnPoint.Length; i++)
        {
            nextShotTime = Time.time + betweenShots;
            Bullet newBullet = Instantiate(bullet, projectileSpawnPoint[i].position, projectileSpawnPoint[i].rotation) as Bullet;
        }
    }

    private void FixedUpdate()
    {
        // Движение корабля
        starshipRigidbody.AddRelativeForce(Vector2.up * verticalInput * velocity);
        starshipRigidbody.AddTorque(-horizontalInput * angulaVelocity);
    }
}