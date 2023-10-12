using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // Reference to the player's Transform.
    public float smoothSpeed = 0.125f;  // The smoothness of camera movement.

    // Offset to control the camera's position relative to the player.
    public Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position for the camera.
            Vector3 desiredPosition = target.position + offset;

            // Use SmoothDamp to smoothly move the camera towards the desired position.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position.
            transform.position = smoothedPosition;
        }
    }
}