using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    private SpawnManager spawnManager;

    public float speed;
    public float turnSpeed;
    private float maxSpeed = 0.5f;
    private float maxTurnSpeed = 100f;

    public virtual void Start()
    {
        speed = Random.Range(0.1f, maxSpeed);
        turnSpeed = Random.Range(1f, maxTurnSpeed);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        transform.position = spawnManager.SpawnPosition();
    }
}
