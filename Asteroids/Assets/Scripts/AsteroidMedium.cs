using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMedium : EnemyBase
{
    private void Awake()
    {
        asteroidCondition = 2;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        spawnManager.SpawnShards(asteroidCondition, transform.position); // запуск механизма дробления
        base.OnTriggerEnter2D(other);
    }
}
