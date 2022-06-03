using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> asteroids;

    private float spawnRate = 1.0f;
    public bool isGameActive;

    public void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget()); // запуск итераторa

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);   // yield возвращает значение итерации через указанное время
            int index = Random.Range(0, asteroids.Count); // индекс от 0 до длинны листа
            Instantiate(asteroids[index]);                // спавн из листа Asteroids
        }
    }
}
