using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Button interactButton; // Reference to the UI button.

    private void Start()
    {
        // Attach a method to the button's click event.
        interactButton.onClick.AddListener(OnInteractButtonClick);
    }

    private void OnInteractButtonClick()
    {
        // Implement your interaction logic here.
        // For example, pick up an item, open a door, etc.
    }
}
