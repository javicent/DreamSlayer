using UnityEngine;

public class UIPositionRelativeToCanvas : MonoBehaviour
{
    public float relativeXMin = 0.0f;
    public float relativeXMax = 1.0f;
    public float relativeYMin = 0.0f;
    public float relativeYMax = 1.0f;

    private RectTransform rectTransform;
    private CanvasSizeManager canvasSizeManager;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasSizeManager = FindObjectOfType<CanvasSizeManager>();

        if (canvasSizeManager != null)
        {
            // Call the method to set the position based on canvas size from CanvasSizeManager.
            SetPositionRelativeToCanvas();
        }
        else
        {
            Debug.LogWarning("CanvasSizeManager not found. Make sure it's in the scene.");
        }
    }

    private void SetPositionRelativeToCanvas()
    {
        if (canvasSizeManager != null)
        {
            float canvasWidth = canvasSizeManager.CanvasWidth;
            float canvasHeight = canvasSizeManager.CanvasHeight;

            float x = Mathf.Lerp(relativeXMin, relativeXMax, rectTransform.pivot.x);
            float y = Mathf.Lerp(relativeYMin, relativeYMax, rectTransform.pivot.y);

            rectTransform.anchoredPosition = new Vector2(x * canvasWidth, y * canvasHeight);
        }
    }
}
