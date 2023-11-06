using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{
    public float interactionRange = 2.0f; // The range at which the player can interact.
    public bool isPickupable = false; // Is the object something the player can pick up?

    private bool isInRange = false;
    private EnemySpawnManager enemySpawnManager; // Reference to the EnemySpawnManager.
    
    private GameManager gameManager;
    private AudioManager audioManager;
    private CaptainCrunch cpnC;
    void Awake()
    {
        enemySpawnManager = FindObjectOfType<EnemySpawnManager>(); // Find and store a reference to the EnemySpawnManager.
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        cpnC = FindObjectOfType<CaptainCrunch>();
    }

    private void Update()
    {
        // Check if the player is in range to interact.
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isPickupable)
            {
                Pickup();
            }
            else
            {
                Interact(); // Define the interaction behavior here.
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void Pickup()
    {
        gameObject.SetActive(false);
    }

    // Define the interaction behavior in this method.
    public void Interact()
    {
        // Access the GameManager and increment currentPhase by one
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.CurrentPhase == 0 || (gameManager != null && gameManager.CurrentPhase != 2 && gameManager.pickupCount > 5))
        {
            gameManager.pickupCount = 0;
            gameManager.CurrentPhase++;
        }
        if(cpnC.isDead || gameManager.EndState)
        {
            audioManager.thanos();
            SceneManager.LoadScene("GameOver");
        }
    }
}
