using UnityEngine;
using UnityEngine.UI;

public class DreamBucksCounter : MonoBehaviour
{
    private Text dreamBucksText; // Reference to the Text component.
    private GameManager gameManager; // Reference to the GameManager script.

    private void Start()
    {
        // Get the Text component on this GameObject.
        dreamBucksText = GetComponent<Text>();

        // Find the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void Update()
    {
        if (dreamBucksText != null && gameManager != null)
        {
            // Update the Text UI element with the pickup count from the GameManager.
            dreamBucksText.text = "Dream Bucks: " + gameManager.GetPickupCount().ToString();
        }
    }
}
