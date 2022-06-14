using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;

    // ��������
    public LineRenderer lineRenderer;
    public Bullet bullet;
    public Transform firePoint;
    private float rayDistance = 20f;

    // �������������� �������
    private float verticalInput;
    private float horizontalInput;
    private float velocity = 120f;
    private float angularVelocity = 300;
    private float deathForce = 5f;

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

        // �������� �������
        shipRigidbody.AddRelativeForce(Vector2.up * velocity * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward * angularVelocity * -horizontalInput * Time.deltaTime);

        // ��������
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
        // �����
        if (Input.GetKey(KeyCode.Mouse1)) Laser();
    }

   
    private void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void Laser()  // �������� ������ ���������� ����
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(firePoint.position, transform.up, rayDistance); // ������ ����, ��� �������� ������ �� ������� ������������

        Draw2DRay(firePoint.position, transform.up * rayDistance);               // ��������� ���
        if (Physics2D.Raycast(firePoint.position, transform.up, rayDistance))   // �������� ���� �� ������������
        {
            Destroy(raycastHit2D.collider.gameObject);                           // ��������� ����� � ������� ����������
        }
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition)
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.relativeVelocity.magnitude > deathForce && !other.gameObject.CompareTag("UFO"))  // ���� ��������� 2 �������� ����������� ������ ���� ������
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("UFO"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}