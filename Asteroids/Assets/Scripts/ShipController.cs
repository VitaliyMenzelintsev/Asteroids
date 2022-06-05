using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;

    // Стрельба
    [SerializeField] 
    private float rayDistance = 50f;
    public LineRenderer lineRenderer;
    private Transform m_transform;   // ????

    public Bullet bullet;
    public Transform firePoint;

    // Характеристики корабля
    private float verticalInput;              // thrustInput
    private float horizontalInput;            // turnInput
    private float velocity = 120f;             // thrust
    private float angularVelocity = 300;      // turnThrust

    //private float deathForce = 3f;

    private void Start()
    {
        m_transform = GetComponent<Transform>();   // лазер
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
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
        // Лазер
        if (Input.GetKeyDown(KeyCode.Mouse1)) Laser();

        // Движение корабля
        shipRigidbody.AddRelativeForce(Vector2.up * velocity * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward * angularVelocity * -horizontalInput * Time.deltaTime);
    }

    private void Shoot()
    {
        // ввести переключатель стрельбы между лазером и пулями
        Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void Laser()           // Стрельба лазером
    {
        if(Physics2D.Raycast(m_transform.position, transform.forward ))    // заменить на RaycastAll скорее всего
        {
            RaycastHit2D _hit = Physics2D.Raycast(firePoint.position, transform.right);
            Draw2DRay(firePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(firePoint.position, firePoint.transform.forward * rayDistance);
        }
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition)   // Рисование лазера
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    //if (other.relativeVelocity.magnitude > deathForce)  // если сложенные 2 скорости коллайдеров больше силы смерти
    //    //{
    //        Destroy(gameObject);
    //        Destroy(other.gameObject);
    //    //}
    //}
}