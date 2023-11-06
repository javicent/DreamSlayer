using UnityEngine;
using UnityEngine.UI;

public class CanvasSizeAdjustment : MonoBehaviour
{
    public Slider widthSlider;
    public Slider heightSlider;

    public delegate void CanvasSizeChangedHandler(Vector2 newSize);
    public event CanvasSizeChangedHandler OnCanvasSizeChanged;

    private Vector2 chosenCanvasSize;

    private void Start()
    {
        // Log the initial slider values for debugging.
        //Debug.Log("Initial Slider Values - Width: " + widthSlider.value + ", Height: " + heightSlider.value);
    }

    public void AdjustCanvasSize()
    {
        float width = widthSlider.value;
        float height = heightSlider.value;

        // Adjust the canvas size based on the slider values.
        chosenCanvasSize = new Vector2(width, height);

        // Save the chosen canvas size in player preferences.
        PlayerPrefs.SetFloat("CanvasWidth", width);
        PlayerPrefs.SetFloat("CanvasHeight", height);
        PlayerPrefs.Save();
    }

}
