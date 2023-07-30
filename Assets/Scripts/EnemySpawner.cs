using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] float spawnRate;
    float nextSpawnTime = 0f;

    private void Update() {
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        if (Time.time > nextSpawnTime) {
            Transform randomSpawnPoint = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnRate;
        }
    }


}
