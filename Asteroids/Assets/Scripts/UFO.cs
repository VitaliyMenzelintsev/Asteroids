using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UFO : EnemyBase
{
    private Transform target;

    //float myCollisionRadius;                            // радиус столкновения Врага
    //float targetCollisionRadius;                        // радиус столкновения цели (Игрока)

    public override void Start()
    {
        speed = 4f;
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            //myCollisionRadius = GetComponent<EdgeCollider2D>().edgeRadius;       // радиус столкновения равен радиусу коллайдера
            //targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;
        }
    }
    public override void Update()
    {
        if (target != null)
        {
            Vector2 flightDirection = (target.position - transform.position).normalized;
            transform.Translate(flightDirection * speed * Time.deltaTime);
        }
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}