using UnityEngine;
using UnityEngine.UI;

public class SliderEventHandler : MonoBehaviour
{
    public Slider widthSlider;
    public Slider heightSlider;
    public CanvasSizeAdjustment canvasSizeAdjustment; // Reference to the CanvasSizeAdjustment script.

    private void Start()
    {
        // Ensure the CanvasSizeAdjustment script is linked in the Inspector.
        if (canvasSizeAdjustment == null)
        {
            Debug.LogError("CanvasSizeAdjustment script is not assigned.");
        }
        else
        {
            // Add event handlers for the slider value changes.
            widthSlider.onValueChanged.AddListener(HandleWidthSliderValueChanged);
            heightSlider.onValueChanged.AddListener(HandleHeightSliderValueChanged);
        }
    }

    private void HandleWidthSliderValueChanged(float value)
    {
        canvasSizeAdjustment.AdjustCanvasSize();
    }

    private void HandleHeightSliderValueChanged(float value)
    {
        canvasSizeAdjustment.AdjustCanvasSize();
    }
}
