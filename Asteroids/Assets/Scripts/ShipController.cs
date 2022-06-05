using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;
    public Bullet bullet;
    public Transform projectileSpawnPoint;

    // �������������� �������
    private float verticalInput;              // thrustInput
    private float horizontalInput;            // turnInput
    private float velocity = 120f;             // thrust
    private float angularVelocity = 300;      // turnThrust

    private float deathForce = 3f;

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
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();

        // �������� �������
        shipRigidbody.AddRelativeForce(Vector2.up * velocity * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward * angularVelocity * -horizontalInput * Time.deltaTime);
    }

    private void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > deathForce)  // ���� ��������� 2 �������� ����������� ������ ���� ������
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}