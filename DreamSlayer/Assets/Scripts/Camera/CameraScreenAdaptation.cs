using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenAdaptation : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Assumes the main camera is the one you want to adapt.

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Make sure you have a main camera in the scene.");
            return;
        }

        AdaptCameraToScreenSize();
    }

    private void AdaptCameraToScreenSize()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Calculate the screen's aspect ratio
        float screenAspect = screenWidth / screenHeight;

        // Calculate the desired aspect ratio (you can set your target aspect ratio here)
        float targetAspect = 16.0f / 9.0f;

        // Calculate the desired size of the camera's orthographic view
        float orthoSize = mainCamera.orthographicSize;

        if (screenAspect > targetAspect)
        {
            orthoSize = mainCamera.orthographicSize * (targetAspect / screenAspect);
        }
        else
        {
            orthoSize = mainCamera.orthographicSize;
        }

        mainCamera.orthographicSize = orthoSize;
    }
}
