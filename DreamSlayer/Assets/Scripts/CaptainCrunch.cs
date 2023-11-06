using UnityEngine;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class CaptainCrunch : MonoBehaviour
{
    public EnemyHealth enemyHealth; // Reference to the EnemyHealth script.
    public Transform[] spawnPoints; // Array of spawn points for new enemies.
    public float damageThreshold = 10f; // Damage threshold to spawn new enemies.
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn.
    private bool invisible = false; // Flag to control visibility.
    private int spawnedEnemyCount = 0;
    private int spawnLimit = 6;
    public float spawnDelay = 2.0f; // Adjust the delay duration as needed.
    public bool isDead = false;

    [field: SerializeField] public EventReference taunt1 { get; private set; }
    [field: SerializeField] public EventReference taunt2 { get; private set; }
    [field: SerializeField] public EventReference taunt3 { get; private set; }

    private GameManager gameManager;

    private Renderer enemyRenderer; // Reference to the enemy's Renderer component.

    // Thresholds at which events should happen
    public float[] eventThresholds = { 40f, 35f, 20f, 10f };
    private int currentEventIndex = 0;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyRenderer = GetComponent<Renderer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float currentHealth = enemyHealth.GetCurrentHealth();

        if (currentHealth <= 0)
        {
            gameManager.EndState = true;
            isDead = true;
            Debug.Log(gameManager.EndState);
        }
        else if (currentHealth % damageThreshold == 0)
        {
            CheckEventThresholds(currentHealth);
        }
    }

    void CheckEventThresholds(float currentHealth)
    {
        for (int i = currentEventIndex; i < eventThresholds.Length; i++)
        {
            if (currentHealth <= eventThresholds[i])
            {
                HandleEventAtThreshold(eventThresholds[i]);
                currentEventIndex = i + 1;
            }
        }
    }

    void HandleEventAtThreshold(float threshold)
    {
        switch (threshold)
        {
            case 40f:
                SpawnEnemiesWithDelay();
                TurnInvisible();
                playTaunt(taunt1);
                break;

            case 35f:
                SpawnEnemiesWithDelay();
                TurnInvisible();
                playTaunt(taunt2);
                break;

            case 20f:
                SpawnEnemiesWithDelay();
                TurnInvisible();
                playTaunt(taunt3);
                break;

            case 10f:
                SpawnEnemiesWithDelay();
                TurnInvisible();
                playTaunt(taunt1);
                break;

            default:
                break;
        }
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        while (spawnedEnemyCount < spawnLimit)
        {
            // Randomly select a spawn point.
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawn a new enemy at the selected spawn point.
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Increment the spawned enemy count.
            spawnedEnemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void TurnInvisible()
    {
        enemyRenderer.enabled = false;
        StartCoroutine(EnableRendererAfterDelay(10.0f));
    }

    IEnumerator EnableRendererAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Re-enable the renderer after the specified delay.
        enemyRenderer.enabled = true;
    }

    void playTaunt(EventReference taunt){
        if (!taunt.IsNull)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(taunt);
            eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform)); // Set 3D position.
            eventInstance.start();

            // Release the FMOD event instance when it's no longer needed.
            eventInstance.release();
        }
    }
}
