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
        StartCoroutine(SpawnTarget()); // ������ ��������a

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);   // yield ���������� �������� �������� ����� ��������� �����
            int index = Random.Range(0, asteroids.Count); // ������ �� 0 �� ������ �����
            Instantiate(asteroids[index]);                // ����� �� ����� Asteroids
        }
    }
}
