using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab;
    [SerializeField]
    float spawnTime;

    const float MIN_Y_OFFSET = -1.2f;
    const float MAX_Y_OFFSET = 1.65f;

    float randomY;
    Coroutine spawnObstacleCoroutine;
    WaitForSeconds spawnSecond;
    Vector2 spawnPoint;

    void Awake()
    {
        spawnSecond = new WaitForSeconds(spawnTime);
        spawnPoint = new Vector2(transform.position.x, randomY);
        StartSpawn();
    }

    public void StartSpawn()
    {
        spawnObstacleCoroutine = StartCoroutine(SpawnObstacleCoroutine());

        IEnumerator SpawnObstacleCoroutine()
        {
            randomY = Random.Range(MIN_Y_OFFSET, MAX_Y_OFFSET);
            spawnPoint.y = randomY;
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint, Quaternion.identity);
            yield return spawnSecond;
            spawnObstacleCoroutine = StartCoroutine(SpawnObstacleCoroutine());
        }
    }

    public void StopSpawnObstacleCoroutine()
    {
        if (spawnObstacleCoroutine != null)
        {
            StopCoroutine(spawnObstacleCoroutine);
            spawnObstacleCoroutine = null;
        }
    }

    public void StopSpawnCoroutines()
    {
        StopAllCoroutines();
    }
}
