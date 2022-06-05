using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLarge : EnemyBase
{
    private void Awake()
    {
        asteroidCondition = 3;
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
        spawnManager.SpawnShards(asteroidCondition, transform.position); 
        base.OnTriggerEnter2D(other);
    }
}
