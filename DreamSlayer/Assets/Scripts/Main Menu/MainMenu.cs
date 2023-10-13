using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Load your game scene here
    }

    public void OpenSettings()
    {
        // Implement settings menu functionality here
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}