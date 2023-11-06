// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class DragPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
// {
//     public PlayerController playerController;
//     private Vector3 startPos;
//     private Vector3 endPos;
//     private bool isSliding = false;

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         startPos = eventData.position;

//         if (!playerController.isSliding)
//         {
//             startPos = eventData.position;
//             playerController.StartDrag();
//         }
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         endPos = eventData.position;

//         // Check if the player is not currently sliding
//         if (!isSliding)
//         {
//             playerController.EndDrag();
//         }
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         Vector3 currentPosition = eventData.position;
//         float horizontalDelta = currentPosition.x - startPos.x;
//         float targetXPosition = playerController.transform.position.x + horizontalDelta;

//         playerController.SetTargetXPosition(targetXPosition);
//     }

//     // Add a method to set the sliding state
//     public void SetSlidingState(bool sliding)
//     {
//         isSliding = sliding;
//     }
// }
