using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private GameManager gameManager;
    public BorderCrossing borderCrossing;

    // Спавн
    private float xRange = 14f;
    private float yRange = 9;
    private Vector2 flyightDirection;

    // Движение
    private float speed;
    private float turnSpeed;
    private float maxSpeed = 0.5f;
    private float maxTurnSpeed = 100f;

    private void Start()
    {
        speed = Random.Range(0.1f, maxSpeed);
        turnSpeed = Random.Range(1f, maxTurnSpeed);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.position = SpawnPosition();         // Спавн позиция

        flyightDirection = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
        borderCrossing = new BorderCrossing();

    }

    private void Update()
    {
        // Перемещение и вращение
        transform.Translate(flyightDirection * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        // Вылет за пределы экрана
        transform.position = borderCrossing.UpdateBorder(transform.position);
    }

    private Vector2 SpawnPosition()
    {
        int spawnPositionIndex = Random.Range(0, 4);

        if (spawnPositionIndex == 0) return new Vector2(Random.Range(-xRange, xRange), yRange);

        if (spawnPositionIndex == 1) return new Vector2(Random.Range(-xRange, xRange), -yRange);

        if (spawnPositionIndex == 2) return new Vector2(xRange, Random.Range(-yRange, yRange));

        if (spawnPositionIndex == 3) return new Vector2(-xRange, Random.Range(-yRange, yRange));

        else return new Vector2(xRange, yRange);
    }
}
