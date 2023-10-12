using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public PlayerController playerController;
    private Vector3 startPos;
    private Vector3 endPos;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        playerController.StartDrag();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        endPos = eventData.position;
        playerController.EndDrag();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = eventData.position;
        float horizontalDelta = currentPosition.x - startPos.x;
        float targetXPosition = playerController.transform.position.x + horizontalDelta;

        playerController.SetTargetXPosition(targetXPosition);
    }
}
