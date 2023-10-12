using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform leftBoundary;
    public Transform rightBoundary;
    public float normalMoveSpeed = 2.0f;
    public float chaseMoveSpeed = 1.0f;
    public float jumpForce = 5.0f;
    public LayerMask groundLayer;
    public float chaseRange = 5.0f;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Initialize the Rigidbody2D component.
        player = GameObject.FindWithTag("Player").transform; // Assuming the player has the "Player" tag.
    }
    void Update()
    {
        // Determine the enemy's current position.
        Vector3 position = transform.position;

        // Calculate the distance to the player.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            // The player is within the chase range; chase the player at a slower speed.
            if (transform.position.x < player.position.x)
            {
                position.x += chaseMoveSpeed * Time.deltaTime;
            }
            else
            {
                position.x -= chaseMoveSpeed * Time.deltaTime;
            }
        }
        else
        {
            // The player is not within the chase range; move left and right as before at normal speed.
            if (movingRight)
            {
                position.x += normalMoveSpeed * Time.deltaTime;
                if (position.x >= rightBoundary.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                position.x -= normalMoveSpeed * Time.deltaTime;
                if (position.x <= leftBoundary.position.x)
                {
                    movingRight = true;
                }
            }
        }

        // Update the enemy's position.
        transform.position = position;

        // Check for ground contact and allow the enemy to jump when grounded.
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Raycast to check if there's ground below the enemy.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        return hit.collider != null;
    }
}
