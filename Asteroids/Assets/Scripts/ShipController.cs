using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;

    // ��������
    [SerializeField] 
    private float rayDistance = 25f;
    public LineRenderer lineRenderer;
    public Transform laserPosition;   // ????

    public Bullet bullet;
    public Transform firePoint;

    // �������������� �������
    private float verticalInput;              // thrustInput
    private float horizontalInput;            // turnInput
    private float velocity = 120f;             // thrust
    private float angularVelocity = 300;      // turnThrust

    //private float deathForce = 3f;

    private void Start()
    {
        /*laserPosition = GetComponent<Transform>(); */  // �����
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
        // �����
        if (Input.GetKey(KeyCode.Mouse1)) Laser();

        // �������� �������
        shipRigidbody.AddRelativeForce(Vector2.up * velocity * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward * angularVelocity * -horizontalInput * Time.deltaTime);
    }

    private void Shoot()
    {
        // ������ ������������� �������� ����� ������� � ������
        Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void Laser()           // �������� �������
    {
        RaycastHit2D[] raycastHit = Physics2D.RaycastAll (firePoint.position, transform.up * rayDistance);
        Draw2DRay(firePoint.position, transform.up * rayDistance);
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition)   // ��������� ������
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    //if (other.relativeVelocity.magnitude > deathForce)  // ���� ��������� 2 �������� ����������� ������ ���� ������
    //    //{
    //        Destroy(gameObject);
    //        Destroy(other.gameObject);
    //    //}
    //}
}