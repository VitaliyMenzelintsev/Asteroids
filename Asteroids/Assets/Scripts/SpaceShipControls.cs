using UnityEngine;

public class SpaceShipControls : MonoBehaviour
{
    public Bullet bullet;
    private Rigidbody2D shipRigidbody;
    public BorderCrossing borderCrossing;

    // Характеристики корабля
    private float verticalInput;            // thrustInput
    private float horizontalInput;          // turnInput
    private float velocity = 4;             // thrust
    private float angulaVelocity = 3;       // turnThrust

    // Стрельба
    public Transform[] projectileSpawnPoint;
    private float nextShotTime;
    private float betweenShots = 0.2f;


    private void Start()
    {
        shipRigidbody = gameObject.GetComponent<Rigidbody2D>();
        borderCrossing = new BorderCrossing();
    }

    private void Update()
    {
        // Input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // Вылет за пределы экрана
        transform.position = borderCrossing.UpdateBorder(transform.position);

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
        shipRigidbody.AddRelativeForce(Vector2.up * verticalInput * velocity);
        shipRigidbody.AddTorque(-horizontalInput * angulaVelocity);
    }
}