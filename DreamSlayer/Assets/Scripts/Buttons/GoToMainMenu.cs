using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("MainMenu"); // Load your game scene here
    }
}
