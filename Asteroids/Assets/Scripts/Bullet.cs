using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private SpawnManager spawnManager;
    private float speed = 25;
    private float lifeTime = 3;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        //spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.Translate(Vector2.up * moveDistance);
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Asteroid"))
    //    {
    //        int asteroidCondition = FindObjectOfType<AsteroidMovement>().asteroidCondition;
    //        spawnManager.SpawnShards(asteroidCondition, transform.position);
    //        Destroy(other.gameObject);
    //    }
    //    Destroy(other.gameObject);
    //    Destroy(gameObject);
    //}
}