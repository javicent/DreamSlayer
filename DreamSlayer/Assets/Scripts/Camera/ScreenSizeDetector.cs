using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeDetector : MonoBehaviour
{
    private void Start()
    {
        // Call a JavaScript function to get the screen size
        Application.ExternalCall("GetScreenSize");
    }

    // This method will be called from JavaScript
    public void SetScreenSize(float width, float height)
    {
        // Use the screen size information to adjust the camera
        Camera.main.orthographicSize = CalculateOrthographicSize(width, height);
    }

    private float CalculateOrthographicSize(float referenceAspect, float screenAspect)
    {
        float targetOrthoSize = Camera.main.orthographicSize;
        
        if (screenAspect > referenceAspect)
        {
            targetOrthoSize *= referenceAspect / screenAspect;
        }
        
        return targetOrthoSize;
    }

}
