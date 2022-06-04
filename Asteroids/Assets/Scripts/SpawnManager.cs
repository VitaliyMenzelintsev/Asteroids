using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> largeAsteroids;
    public List<GameObject> mediumAsteroids;
    public List<GameObject> smallAsteroids;

    private float spawnRate = 2.0f;
    public bool isGameActive;

    private float xRange = 14f;
    private float yRange = 9f;

    public void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnAsteroids());
    }
    IEnumerator SpawnAsteroids()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, largeAsteroids.Count);
            GameObject asteroidLarge = Instantiate(largeAsteroids[index], SpawnPosition(), transform.rotation);
            asteroidLarge.GetComponent<AsteroidMovement>().asteroidCondition = 3;
        }
    }

    public void SpawnShards(int asteroidCondition, Vector2 positionToSpawn)
    {
        if (asteroidCondition == 3)
        {
            for (int i = 0; i < asteroidCondition - 1; i++)
            {
                int index = Random.Range(0, mediumAsteroids.Count);
                GameObject asteroidMedium = Instantiate(mediumAsteroids[index], positionToSpawn, transform.rotation);
                asteroidMedium.GetComponent<AsteroidMovement>().asteroidCondition = 2;
            }
        }
        else if (asteroidCondition == 2)
        {
            for (int i = 0; i < asteroidCondition; i++)
            {
                int index = Random.Range(0, smallAsteroids.Count);
                GameObject asteroidSmall = Instantiate(smallAsteroids[index], positionToSpawn, transform.rotation);
                asteroidSmall.GetComponent<AsteroidMovement>().asteroidCondition = 1;
            }
        }
        else if (asteroidCondition == 1)
        {
            return;
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