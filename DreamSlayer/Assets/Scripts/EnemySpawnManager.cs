using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3.0f;
    public float spawnDelay = 5.0f; 
    public int spawnLimit = 10; 
    public bool followEnemyOnSpawn = true; 
    public float followEnemyDuration = 5.0f; 
    public int phaseToSpawn = 1;

    private float spawnTimer = 0.0f;
    private GameManager gameManager;
    private CameraController cameraController;

    private int enemiesSpawned = 0;

    private bool delayComplete = false;
    private bool isFollowingEnemy = false;
    private float followTimer = 0.0f;

    private bool delayStarted = false; 

    void Start()
    {
        gameManager = GameManager.Instance;
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        if (gameManager.CurrentPhase == phaseToSpawn && enemiesSpawned < spawnLimit)
        {
            if (!delayStarted)
            {
                StartCoroutine(StartSpawnDelay());
                delayStarted = true;
            }

            if (delayComplete)
            {
                spawnTimer += Time.deltaTime;
                if (spawnTimer >= spawnInterval)
                {
                    SpawnEnemy();
                    spawnTimer = 0.0f;
                }
            }
        }

        if (isFollowingEnemy)
        {
            followTimer += Time.deltaTime;
            if (followTimer >= followEnemyDuration)
            {
                StopFollowingEnemy();
            }
        }

        if (gameManager.CurrentPhase != phaseToSpawn)
        {
            delayStarted = false;
            enemiesSpawned = 0;
        }
    }

    IEnumerator StartSpawnDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        delayComplete = true;
    }

    void SpawnEnemy()
    {
        if (enemiesSpawned < spawnLimit)
        {
            if (delayComplete) 
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemiesSpawned++;

                if (enemiesSpawned >= spawnLimit)
                {
                    delayComplete = false;
                }

                if (followEnemyOnSpawn)
                {
                    StartFollowingEnemy(enemy.transform);
                }
            }
        }
    }

    void StartFollowingEnemy(Transform enemyTransform)
    {
        isFollowingEnemy = true;
        followTimer = 0.0f;
        cameraController.SetEnemyToFocusOn(enemyTransform);
    }

    void StopFollowingEnemy()
    {
        isFollowingEnemy = false;
        cameraController.StopFocusingOnEnemy();
    }
}
