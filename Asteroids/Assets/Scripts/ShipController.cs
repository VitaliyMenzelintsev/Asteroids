using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D shipRigidbody;
    private BorderCrossing borderCrossing;

    // Стрельба
    [SerializeField]
    private float rayDistance = 25f;
    public LineRenderer lineRenderer;
    //public Transform laserPosition;   // ????

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

        // Движение корабля
        shipRigidbody.AddRelativeForce(Vector2.up * velocity * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.forward * angularVelocity * -horizontalInput * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // Стрельба
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
        // Лазер
        if (Input.GetKey(KeyCode.Mouse1)) Laser();
    }

    private void Shoot()
    {
        // ввести переключатель стрельбы между лазером и пулями
        Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    private void Laser()      
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(firePoint.position, transform.up, rayDistance); // создал поле, где хранятся данные об обьекте столкновения

        Draw2DRay(firePoint.position, transform.up * rayDistance);               // нарисовал луч
        if (Physics2D.Raycast (firePoint.position, transform.up, rayDistance))   // проверил есть ли столкновение
        {
            Destroy(raycastHit2D.collider.gameObject);                           // уничтожил обьет с которым столкнулся
        }
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition) 
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