using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    // и для НЛО обработку движения полностью переписать

    public BorderCrossing borderCrossing;
    public SpawnManager spawnManager;

    // Направление движения. Остаётся для всех астероидов. Для НЛО не используется
    private float xRange = 14f;
    private float yRange = 9;
    private Vector2 flightDirection;

    // Скоростные характеристики. 
    public float speed;
    public float turnSpeed;
    public float maxSpeed = 0.5f;
    public float maxTurnSpeed = 100f;

    public int asteroidCondition = 3;

    public virtual void Start()
    {
        speed = Random.Range(0.1f, maxSpeed) * 3 / asteroidCondition;    // переделать прибавку к скорости после раскола
        turnSpeed = Random.Range(1f, maxTurnSpeed);

        flightDirection = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
        borderCrossing = new BorderCrossing();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    public virtual void Update()
    {
        transform.Translate(flightDirection * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        transform.position = borderCrossing.UpdateBorder(transform.position);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);      
    }
}
