using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int waveCounter = 0;
    [SerializeField] Transform[] spawnPoints;
    PlayerMovement playerMovement;
    CanvasManager canvasManager;
    bool waveStarted = true;
    [SerializeField] GameObject enemy;
    float timeBetweenSpawn = 0.3f;
    float waveTimer;
    float pauseTimer;

    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        waveCounter += 1;
        canvasManager.setWaveText(waveCounter);
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        if (waveTimer > 60)
        {
            StopAllCoroutines();
            Enemy[] allEnemies = FindObjectsOfType<Enemy>();
            if (allEnemies.Length > 0)
            {
                foreach (Enemy enemy in allEnemies)
                {
                    Destroy(enemy.gameObject);
                }
            }

            waveStarted = false;
            pauseTimer += Time.deltaTime;
            playerMovement.SetHealth(300);
            canvasManager.setTimer("Rest timer " + (10 - (int)pauseTimer));
            if (pauseTimer > 10)
            {
                waveTimer = 0;
                waveCounter += 1;
                canvasManager.setWaveText(waveCounter);
            }
        }
        else
        {
            waveTimer += Time.deltaTime;
            canvasManager.setTimer("Wave timer " + (60 - (int)waveTimer));

            if (!waveStarted)
            {
                waveStarted = true;
                timeBetweenSpawn += 0.1f;
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine(SpawnEnemy());
    }
}
