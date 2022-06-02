using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 30;
    private float lifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, lifeTime);         
    }

    private void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector2.up * moveDistance);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}