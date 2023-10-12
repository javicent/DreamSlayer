using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public float interactionRange = 1.0f; // Adjust the range as needed.
    public LayerMask pickupLayer; // Define the layer for pickup objects.

    void Update()
    {
        // Detect pickup objects within the interaction range.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, pickupLayer);

        foreach (Collider2D collider in colliders)
        {
            // Check if the detected object has a Pickup component.
            Pickup pickup = collider.GetComponent<Pickup>();
            if (pickup != null)
            {
                // Perform the pickup action (e.g., increase player's score or activate a power-up).
                pickup.Collect();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualize the interaction range in the Unity Editor.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
