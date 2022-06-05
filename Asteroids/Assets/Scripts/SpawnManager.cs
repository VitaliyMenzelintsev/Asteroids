using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> largeAsteroids;
    public List<GameObject> mediumAsteroids;
    public List<GameObject> smallAsteroids;
    public Transform UFO;

    private float spawnRate = 2.5f;
    private float spawnRateUFO;
    public bool isGameActive;

    private float xRange = 14f;
    private float yRange = 9f;
    private int asteroidsCount = 0;


    public void Start()
    {
        isGameActive = true;
        spawnRateUFO = Random.Range(1f, 2f);
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnUFOs());
    }

    private void Update()
    {
        // добавить старт корутины при условии для НЛО и Больших Астероидов
    }
    IEnumerator SpawnAsteroids()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, largeAsteroids.Count);
            // добавить иф, который отслеживает счётчик 
            if (asteroidsCount <= 4)
            {
                Instantiate(largeAsteroids[index], SpawnPosition(), transform.rotation);
                asteroidsCount++;
            }
        }
    }

    IEnumerator SpawnUFOs()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRateUFO);
            Instantiate(UFO, SpawnPosition(), transform.rotation);
            spawnRateUFO = Random.Range(2f, 4f);
        }
    }



    public void SpawnShards(int asteroidCondition, Vector2 positionToSpawn)
    {
        if (asteroidCondition == 3)
        {
            for (int i = 0; i < asteroidCondition - 1; i++)
            {
                int index = Random.Range(0, mediumAsteroids.Count);
                /*GameObject asteroidMedium = */Instantiate(mediumAsteroids[index], positionToSpawn, transform.rotation);
                //asteroidMedium.GetComponent<AsteroidMovement>().asteroidCondition = 2;
            }
            asteroidsCount--;
        }
        else if (asteroidCondition == 2)
        {
            for (int i = 0; i < asteroidCondition; i++)
            {
                int index = Random.Range(0, smallAsteroids.Count);
                /*GameObject asteroidSmall = */Instantiate(smallAsteroids[index], positionToSpawn, transform.rotation);
                //asteroidSmall.GetComponent<AsteroidMovement>().asteroidCondition = 1;
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