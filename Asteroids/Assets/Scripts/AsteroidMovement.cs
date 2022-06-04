using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : EnemyMovement
{
    private BorderCrossing borderCrossing;

    // Направление движения
    private float xRange = 14f;
    private float yRange = 9;
    private Vector2 flyightDirection;

    public override void Start()
    {
        base.Start();

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
}
