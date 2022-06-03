using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;
    public Bullet bullet;
    public Transform[] projectileSpawnPoint;

    // �������������� �������
    private float verticalInput;            // thrustInput
    private float horizontalInput;          // turnInput
    private float velocity = 4;             // thrust
    private float angulaVelocity = 3;       // turnThrust


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

        // ����� �� ������� ������
        transform.position = borderCrossing.UpdateBorder(transform.position);

        // ��������
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < projectileSpawnPoint.Length; i++)
        {
            Bullet newBullet = Instantiate(bullet, projectileSpawnPoint[i].position, projectileSpawnPoint[i].rotation);
        }
    }

    private void FixedUpdate()
    {
        // �������� �������
        shipRigidbody.AddRelativeForce(Vector2.up * verticalInput * velocity);
        shipRigidbody.AddTorque(-horizontalInput * angulaVelocity);
    }
}