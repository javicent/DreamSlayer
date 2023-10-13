using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 3.0f;
    public float spawnDelay = 5.0f; // Delay in seconds before spawning enemies
    public int spawnLimit = 10; // Maximum number of enemies to spawn
    public bool followEnemyOnSpawn = true; // Whether to follow the enemy on spawn
    public float followEnemyDuration = 5.0f; // Duration to follow the enemy
    public int phaseToSpawn = 1;

    private float spawnTimer = 0.0f;
    private GameManager gameManager;
    private CameraController cameraController;

    private int enemiesSpawned = 0;

    private bool delayComplete = false;
    private bool isFollowingEnemy = false;
    private float followTimer = 0.0f;

    private bool delayStarted = false; // Flag to track if the delay has been started

    void Start()
    {
        gameManager = GameManager.Instance; // Get a reference to the GameManager.
        cameraController = FindObjectOfType<CameraController>(); // Find and reference the CameraController.
    }

    void Update()
    {
        if (gameManager.CurrentPhase == phaseToSpawn && enemiesSpawned < spawnLimit)
        {
            if (!delayStarted)
            {
                StartCoroutine(StartSpawnDelay()); // Start the delay only when the phase matches
                delayStarted = true; // Mark the delay as started
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
            delayStarted = false; // Reset delayStarted when the phase changes
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
            if (delayComplete) // Check if the delay is complete before spawning
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemiesSpawned++;

                if (enemiesSpawned >= spawnLimit)
                {
                    delayComplete = false; // Only set delayComplete to false if the spawn limit is reached
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
