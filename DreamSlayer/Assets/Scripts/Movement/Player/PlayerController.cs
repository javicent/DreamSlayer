using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float jumpForce = 10.0f; // Adjust the jump force as needed
    private float targetXPosition;
    private bool isDragging = false;
    private bool canJump = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDragging)
        {
            // Move the player horizontally towards the target X position
            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.MoveTowards(currentPosition.x, targetXPosition, moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
        }

        if (canJump && Input.GetButtonDown("Jump")) // Check for jump input
        {
            Jump(); // Call the jump method
        }
    }

    public void StartDrag()
    {
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    public void SetTargetXPosition(float xPosition)
    {
        targetXPosition = xPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("can jump");
            canJump = true;
        }
    }

    // New Jump method to handle jumping
    public void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
