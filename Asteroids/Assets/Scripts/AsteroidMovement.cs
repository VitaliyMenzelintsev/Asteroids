using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private BorderCrossing borderCrossing;
    private SpawnManager spawnManager;

    // Направление движения
    private float xRange = 14f;
    private float yRange = 9;
    private Vector2 flightDirection;

    // Скоростные характеристики
    private float speed;
    private float turnSpeed;
    private float maxSpeed = 0.5f;
    private float maxTurnSpeed = 100f;

    [HideInInspector]
    public int asteroidCondition; //3 large, 2 medium, 1 small
    
    public void Start()
    {
        speed = Random.Range(0.1f, maxSpeed) * 3 / asteroidCondition;   // переделать прибавку к скорости после раскола
        turnSpeed = Random.Range(1f, maxTurnSpeed);

        flightDirection = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
        borderCrossing = new BorderCrossing();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void Update()
    {
        // Перемещение и вращение
        transform.Translate(flightDirection * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        // Вылет за пределы экрана
        transform.position = borderCrossing.UpdateBorder(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        spawnManager.SpawnShards(asteroidCondition, transform.position);
        Destroy(gameObject);
    }
}
