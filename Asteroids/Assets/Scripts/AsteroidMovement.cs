using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : EnemyMovement
{
    private BorderCrossing borderCrossing;

    // ����������� ��������
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
        // ����������� � ��������
        transform.Translate(flyightDirection * speed * Time.deltaTime);
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);

        // ����� �� ������� ������
        transform.position = borderCrossing.UpdateBorder(transform.position);
    }
}
