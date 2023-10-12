using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Define the behavior when the pickup is collected.
    public void Collect()
    {
        // Add code here to handle the pickup when collected.
        // This can include increasing the player's score, health, or any other gameplay effect.
        // You can also play a collection animation or sound effect.

        // Destroy the pickup object once it's collected.
        Destroy(gameObject);
    }
}
