// using UnityEngine;
// using UnityEngine.UI;

// public class MovementController : MonoBehaviour
// {
//     public PlayerController playerController; // Reference to the PlayerController script

//     public bool isMovingLeft = false;
//     public bool isMovingRight = false;

//     public Button moveLeftButton;  // Assign your left button in the Inspector.
//     public Button moveRightButton; // Assign your right button in the Inspector.

//     private void Start()
//     {
//         // Add click event listeners to the buttons.
//         moveLeftButton.onClick.AddListener(StartMovingLeft);
//         moveLeftButton.onClick.AddListener(StopMovingLeft);
//         moveRightButton.onClick.AddListener(StartMovingRight);
//         moveRightButton.onClick.AddListener(StopMovingRight);
//     }

//     private void StartMovingLeft()
//     {
//         isMovingLeft = true;
//     }

//     private void StopMovingLeft()
//     {
//         isMovingLeft = false;
//     }

//     private void StartMovingRight()
//     {
//         isMovingRight = true;
//     }

//     private void StopMovingRight()
//     {
//         isMovingRight = false;
//     }

//     private void Update()
//     {
//         if (isMovingLeft)
//         {
//             playerController.MoveLeft();
//         }
//         else if (isMovingRight)
//         {
//             playerController.MoveRight();
//         }
//         else
//         {
//             playerController.StopMoving();
//         }
//     }
// }
