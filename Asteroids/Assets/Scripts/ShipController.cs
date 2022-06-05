using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;

    // Стрельба
    [SerializeField] 
    private float rayDistance = 25f;
    public LineRenderer lineRenderer;
    public Transform laserPosition;   // ????

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
        /*laserPosition = GetComponent<Transform>(); */  // лазер
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
        if (Input.GetKey(KeyCode.Mouse1)) Laser();

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
        RaycastHit2D[] raycastHit = Physics2D.RaycastAll (firePoint.position, transform.up * rayDistance);
        Draw2DRay(firePoint.position, transform.up * rayDistance);
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