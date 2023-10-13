using UnityEngine;
using TMPro;

public class TextBoxController : MonoBehaviour
{
    public TextMeshProUGUI textBox; // Reference to the TextMeshPro component you want to control.
    private GameManager gameManager; // Reference to your GameManager script.

    [SerializeField]
    private int phaseRequirement = 1; // Serialized field for the phase requirement.

    [SerializeField]
    private float delayDuration = 2.0f; // Serialized field for the delay duration.

    [SerializeField]
    private float showDuration = 5.0f; // Serialized field for how long the text is shown.

    private bool isTextShowing = false;
    private bool alreadyShown = false; // Added flag to track if the text has already been shown.
    private float delayTimer = 0f;
    private float showTimer = 0f;

    private void Start()
    {
        // Find and store a reference to the GameManager in the scene.
        gameManager = FindObjectOfType<GameManager>();

        // Initially hide the text.
        textBox.enabled = false;
    }

    private void Update()
    {
        int currentPhase = gameManager.CurrentPhase;

        // Check if the currentPhase matches the phaseRequirement.
        if (currentPhase == phaseRequirement && !alreadyShown)
        {
            // The current phase matches the requirement, and text has not been shown yet.

            if (!isTextShowing)
            {
                // Delay timer: Wait for the specified delay duration.
                delayTimer += Time.deltaTime;
                if (delayTimer >= delayDuration)
                {
                    // Show the text and start the show timer.
                    textBox.enabled = true;
                    isTextShowing = true;
                }
            }
            else
            {
                // The text is currently showing.

                // Show timer: Keep the text shown for the specified duration.
                showTimer += Time.deltaTime;
                if (showTimer >= showDuration)
                {
                    // Hide the text, set the flag to indicate it's already shown, and reset the timers.
                    textBox.enabled = false;
                    alreadyShown = true;
                    isTextShowing = false;
                    delayTimer = 0f;
                    showTimer = 0f;
                }
            }
        }
        else
        {
            // The current phase doesn't match the requirement.

            // Hide the text and reset the timers.
            textBox.enabled = false;
            isTextShowing = false;
            delayTimer = 0f;
            showTimer = 0f;
        }
    }
}
