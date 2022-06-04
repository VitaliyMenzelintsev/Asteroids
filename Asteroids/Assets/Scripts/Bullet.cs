using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 25;
    private float lifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, lifeTime);         
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector2.up * moveDistance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}