using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pickupCountText; // Reference to the UI Text element for displaying the pickup count.

    // Reference to the GameManager.
    private GameManager gameManager;

    private void Start()
    {
        // Find the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void Update()
    {
        // Check if the pickupCountText and gameManager are available.
        if (pickupCountText != null && gameManager != null)
        {
            // Update the UI Text element with the pickup count from the GameManager.
            pickupCountText.text = "Pickup Count: " + gameManager.GetPickupCount().ToString();
        }
    }
}
