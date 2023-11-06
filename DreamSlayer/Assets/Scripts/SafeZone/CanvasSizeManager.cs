using UnityEngine;

public class CanvasSizeManager : MonoBehaviour
{
    public float CanvasWidth { get; private set; }
    public float CanvasHeight { get; private set; }

    private void Start()
    {
        // Load the chosen canvas size from player preferences.
        float savedWidth = PlayerPrefs.GetFloat("CanvasWidth", 1920f);
        float savedHeight = PlayerPrefs.GetFloat("CanvasHeight", 1080f);

        CanvasWidth = savedWidth;
        CanvasHeight = savedHeight;

        // Adjust the canvas size in this scene.
        AdjustCanvasSize(CanvasWidth, CanvasHeight);
    }

    public void AdjustCanvasSize(float width, float height)
    {
        // Get the RectTransform of the Canvas component.
        //RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

        // Adjust the canvas size based on the chosen width and height.
        //canvasRectTransform.sizeDelta = new Vector2(width, height);

        Camera.main.aspect = width / height;
    }
}
