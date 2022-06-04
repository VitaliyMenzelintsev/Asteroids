using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> asteroids;
    public List<GameObject> asteroidsMedium;
    public List<GameObject> asteroidShards;

    private float spawnRate = 2.0f;
    public bool isGameActive;

    private float xRange = 14f;
    private float yRange = 9;
    
    public void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnAsteroids()); 
    }
    IEnumerator SpawnAsteroids()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);   // yield возвращает значение итерации через указанное время
            int index = Random.Range(0, asteroids.Count); // индекс от 0 до длинны листа
            Instantiate(asteroids[index]);                // спавн из листа Asteroids
        }
    }
    public Vector2 SpawnPosition()
    {
        int spawnPositionIndex = Random.Range(0, 4);

        if (spawnPositionIndex == 0) return new Vector2(Random.Range(-xRange, xRange), yRange);

        if (spawnPositionIndex == 1) return new Vector2(Random.Range(-xRange, xRange), -yRange);

        if (spawnPositionIndex == 2) return new Vector2(xRange, Random.Range(-yRange, yRange));

        if (spawnPositionIndex == 3) return new Vector2(-xRange, Random.Range(-yRange, yRange));

        else return new Vector2(xRange, yRange);
    }
}