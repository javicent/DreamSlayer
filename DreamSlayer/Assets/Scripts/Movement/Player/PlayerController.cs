using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float jumpForce = 10.0f; // Adjust the jump force as needed
    private float targetXPosition;
    private bool isDragging = false;
    private bool canJump = true;
    private Rigidbody2D rb;

    public Button interactButton; // Reference to the UI button for interactions
    private GameManager gameManager; // Reference to the GameManager

    private Collider2D triggerCollider; // Reference to the trigger collider
    private InteractableObject currentInteractableObject; // Store the current interactable object in range

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Attach a method to the button's click event.
        interactButton.onClick.AddListener(OnInteractButtonClick);

        // Find and store a reference to the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        // Get the trigger collider component on the player character.
        triggerCollider = GetComponent<Collider2D>();
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

        // Check for interaction range with the currentInteractableObject
        if (currentInteractableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            // Perform the interaction with the current object
            currentInteractableObject.Interact();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            // Store the reference to the current interactable object.
            InteractableObject interactable = other.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                currentInteractableObject = interactable;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            // Clear the reference to the current interactable object.
            currentInteractableObject = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
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

    // Handle button click event
    public void OnInteractButtonClick()
    {
        // If there is a currentInteractableObject, perform the interaction
        if (currentInteractableObject != null)
        {
            currentInteractableObject.Interact();
        }
    }
}
