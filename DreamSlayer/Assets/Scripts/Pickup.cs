using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isPickable = true; // Indicates whether the pickup is available for collection.

    private GameManager gameManager; // Reference to the GameManager script.

    private void Start()
    {
        // Find the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    public void Collect()
    {
        if (isPickable)
        {
            // Perform the pickup action (e.g., increase player's score or activate a power-up).
            // You can also play a collection animation or sound effect.

            // Increment the pickup count through the GameManager.
            gameManager.IncrementPickupCount();

            // Destroy the pickup object once it's collected.
            Destroy(gameObject);
        }
    }
}
