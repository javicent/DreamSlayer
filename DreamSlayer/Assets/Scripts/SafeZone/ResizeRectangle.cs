using UnityEngine;
using UnityEngine.UI;

public class ResizeRectangle : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasSizeAdjustment canvasSizeAdjustment;

    private void Awake()
    {
        // Get a reference to the RectTransform of the Rectangle GameObject.
        rectTransform = GetComponent<RectTransform>();

        // Find the CanvasSizeAdjustment script.
        canvasSizeAdjustment = FindObjectOfType<CanvasSizeAdjustment>();
    }

    private void Start()
    {
        // Subscribe to the OnCanvasSizeChanged event.
        if (canvasSizeAdjustment != null)
        {
            canvasSizeAdjustment.OnCanvasSizeChanged += HandleCanvasSizeChanged;
        }

        // Initialize the rectangle size based on the current canvas size.
        UpdateRectangleSize();
    }

    private void HandleCanvasSizeChanged(Vector2 newSize)
    {
        // Set the size of the rectangle to match the new canvas size.
        rectTransform.sizeDelta = newSize;
    }

    private void UpdateRectangleSize()
    {
        if (canvasSizeAdjustment != null)
        {
            // Get the initial canvas size from the CanvasSizeAdjustment script.
            Vector2 initialCanvasSize = new Vector2(canvasSizeAdjustment.widthSlider.value, canvasSizeAdjustment.heightSlider.value);

            // Set the size of the rectangle to match the initial canvas size.
            rectTransform.sizeDelta = initialCanvasSize;
        }
    }
}
