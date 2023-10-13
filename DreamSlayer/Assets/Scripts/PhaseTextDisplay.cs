using UnityEngine;
using UnityEngine.UI;

public class PhaseTextDisplay : MonoBehaviour
{
    public Text phaseText;
    private GameManager gameManager;
    public int visiblePhase = 2; // Change this to the phase when you want the text to be visible.

    private void Start()
    {
        gameManager = GameManager.Instance;
        phaseText = GetComponent<Text>();
    }

    private void Update()
    {
        if (gameManager != null && phaseText != null)
        {
            if (gameManager.CurrentPhase == visiblePhase)
            {
                phaseText.enabled = true; // Make the text visible.
            }
            else
            {
                phaseText.enabled = false; // Hide the text when it's not the visible phase.
            }
        }
    }
}
