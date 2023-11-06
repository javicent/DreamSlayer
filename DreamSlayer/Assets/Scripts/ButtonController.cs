using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName); // Load your game scene here
    }
}
