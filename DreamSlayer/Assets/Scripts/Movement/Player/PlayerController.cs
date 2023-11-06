using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the speed as needed
    public float slideSpeed = 10.0f; // Adjust the sliding speed
    private float targetXPosition;
    private bool isSliding = false; // Added sliding state
    private Rigidbody2D rb;
    private Vector2 slidingDirection; // Direction to slide

    public Button interactButton; // Reference to the UI button for interactions
    public Button slideButton; // Reference to the UI button for sliding
    public GameManager gameManager; // Reference to the GameManager

    private Collider2D triggerCollider; // Reference to the trigger collider
    private InteractableObject currentInteractableObject; // Store the current interactable object in range

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    private Animator playerAnimator;

    [SerializeField] private RuntimeAnimatorController originalPlayerController; // Assign the original player controller in the Inspector.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Attach methods to the buttons' click events.
        interactButton.onClick.AddListener(OnInteractButtonClick);
        slideButton.onClick.AddListener(OnSlideButtonClick);

        // Find and store a reference to the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        // Get the trigger collider component on the player character.
        triggerCollider = GetComponent<Collider2D>();

        // Get a reference to the SpriteRenderer component.
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the player's Animator component.
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for player input to determine the movement direction.
        float horizontalInput = Input.GetAxis("Horizontal");

        if (isSliding)
        {
            if(spriteRenderer.flipX){
                rb.velocity = slidingDirection * slideSpeed * -1;
            }else{
                rb.velocity = slidingDirection * slideSpeed;
            }
        }
        else
        {
            // Reset velocity
            rb.velocity = Vector2.zero;

            if (isMovingLeft)
            {
                MoveLeft();
                slidingDirection = Vector2.left; // Set sliding direction to left
                spriteRenderer.flipX = true; // Flip the sprite when moving left
            }
            else if (isMovingRight)
            {
                MoveRight();
                slidingDirection = Vector2.right; // Set sliding direction to right
                spriteRenderer.flipX = false; // Unflip the sprite when moving right
            }
            else
            {
                // Neither button is pressed
                StopMoving();
            }
        }
    }

    public void MoveLeftStart()
    {
        isMovingLeft = true;
        spriteRenderer.flipX = true; // Flip the sprite when moving left
    }

    public void MoveLeftStop()
    {
        isMovingLeft = false;
    }

    public void MoveRightStart()
    {
        isMovingRight = true;
        spriteRenderer.flipX = false; // Unflip the sprite when moving right
    }

    public void MoveRightStop()
    {
        isMovingRight = false;
    }

    public void StartSlide(Vector2 direction)
    {
        if (!isSliding)
        {
            // Set the player GameObject to a layer that doesn't interact with enemies.
            gameObject.layer = LayerMask.NameToLayer("SlidingPlayer");
            isSliding = true;
            slidingDirection = direction.normalized;
            StartCoroutine(EndSlide());
        }
    }

    private IEnumerator EndSlide()
    {
        yield return new WaitForSeconds(0.5f); // Adjust the duration as needed.
        isSliding = false;

        // Set the player GameObject back to the "Player" layer.
        gameObject.layer = LayerMask.NameToLayer("Player");
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

    // Handle button click events
    public void OnInteractButtonClick()
    {
        // If there is a currentInteractableObject, perform the interaction
        if (currentInteractableObject != null)
        {
            currentInteractableObject.Interact();
        }
    }

    // Handle slide button click event
    public void OnSlideButtonClick()
    {
        Vector2 slideDirection = new Vector2(1f, 0f); // Change this to your desired slide direction.
        StartSlide(slideDirection);
    }

    public void MoveLeft()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x -= moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void MoveRight()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero; // You can apply braking or simply set velocity to zero to stop the player smoothly.
    }
    
    // Method to switch back to the original player animation controller.
    public void SwitchToOriginalController()
    {
        if (playerAnimator != null && originalPlayerController != null)
        {
            playerAnimator.runtimeAnimatorController = originalPlayerController;
        }
    }
}
