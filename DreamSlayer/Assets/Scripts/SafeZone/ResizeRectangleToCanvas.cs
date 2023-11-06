using UnityEngine;
using UnityEngine.UI;

public class ResizeRectangleToCanvas : MonoBehaviour
{
    public Canvas canvas;  // Reference to the canvas containing the rectangle.
    public Slider widthSlider;  // Reference to the slider controlling the width.
    public Slider heightSlider; // Reference to the slider controlling the height.

    private RectTransform rectTransform;
    private RectTransform canvasRectTransform;

    void Start()
    {
        // Get the RectTransform of the rectangle and the canvas.
        rectTransform = GetComponent<RectTransform>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();

        // Resize the rectangle to match the canvas size initially.
        ResizeToCanvasSize();
    }

    void Update()
    {
        // Check for slider value changes and update the rectangle size.
        if (widthSlider.value != rectTransform.sizeDelta.x || heightSlider.value != rectTransform.sizeDelta.y)
        {
            ResizeToCanvasSize();
        }

        //Debug.Log("Current Canvas Size: " + canvas.GetComponent<RectTransform>().sizeDelta);

        // Check if the rectangle is the same size as the canvas.
        bool sameSize = IsSameSizeAsCanvas();
        if (sameSize)
        {
            // The rectangle is the same size as the canvas.
            //Debug.Log("Rectangle is the same size as the canvas.");
        }
        else
        {
            // The rectangle is not the same size as the canvas.
            //Debug.Log("Rectangle is not the same size as the canvas.");
        }
    }

    void ResizeToCanvasSize()
    {
        // Get the width and height values from the sliders.
        float width = widthSlider.value;
        float height = heightSlider.value;

        // Update the size of the rectangle.
        rectTransform.sizeDelta = new Vector2(width, height);
    }

    bool IsSameSizeAsCanvas()
    {
        return rectTransform.sizeDelta == canvasRectTransform.sizeDelta;
    }
}
