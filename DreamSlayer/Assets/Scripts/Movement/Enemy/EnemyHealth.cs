using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth;

    public Rigidbody2D rb; // Reference to the Rigidbody2D component.
    public float jumpForce = 5.0f; // Adjust the jump force as needed.
    public GameObject pickupPrefab; // Reference to the pickup sprite prefab.
    public float pickupDelay = 1.0f; // Delay before the loot becomes available for pickup.

    private Collider2D enemyCollider; // Reference to the enemy's collider.

    void Start()
    {
        currentHealth = maxHealth;
        enemyCollider = GetComponent<Collider2D>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            StartCoroutine(DieWithDelay());
        }
        else
        {
            // Apply a jump backward force to the enemy.
            JumpBackward();
        }
    }

    IEnumerator DieWithDelay()
    {
        JumpBackward();

        // Delay before dropping the loot.
        yield return new WaitForSeconds(pickupDelay);

        // Disable the enemy's collider.
        enemyCollider.enabled = false;


        // Instantiate the pickup object at the enemy's position.
        Instantiate(pickupPrefab, transform.position, Quaternion.identity);

        // Add code to handle enemy death, such as playing death animations.
        Destroy(gameObject); // Optionally remove the enemy GameObject.
    }

    void JumpBackward()
    {
        // Calculate the direction from the enemy to the player.
        Vector2 jumpDirection = (PlayerPosition() - new Vector2(transform.position.x, transform.position.y)).normalized;

        // Apply an upward jump force in the opposite direction.
        rb.AddForce(-jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    Vector2 PlayerPosition()
    {
        // Implement a method to get the player's position here. You can use a tag or other methods to find the player GameObject.
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            return player.transform.position;
        }
        else
        {
            // Return a default position or handle the case where the player is not found.
            return Vector2.zero;
        }
    }
}
