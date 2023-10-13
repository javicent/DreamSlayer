using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text pickupCountText; // Reference to a UI Text element for displaying the pickup count.
    public int pickupCount = 0; // Counter for tracking pickups.
    
    // Singleton pattern to ensure only one GameManager exists.
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject manager = new GameObject("GameManager");
                    _instance = manager.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    private int currentPhase = 0; // Current game phase.
    
    public int CurrentPhase
    {
        get { return currentPhase; }
        set { currentPhase = value; }
    }
    
    private bool endState = false;

    public bool EndState
    {
        get { return endState; }
        set { endState = value; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager persistent between scenes.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementPickupCount()
    {
        pickupCount++;
        UpdatePickupCountText();
    }

    public int GetPickupCount()
    {
        return pickupCount;
    }

    private void UpdatePickupCountText()
    {
        if (pickupCountText != null)
        {
            pickupCountText.text = "Pickup Count: " + pickupCount.ToString();
        }
    }

    // Add phase-specific logic here
    void Update()
    {
        switch (currentPhase)
        {
            case 0:
                // Phase 0 specific logic
                break;
            case 1:
                // Phase 1 specific logic
                break;
            // Add more cases for other phases as needed
        }
    }

    // Method to switch to a new game phase
    public void SwitchToPhase(int phase)
    {
        // Add logic for phase transitions, setup, and cleanup here
        currentPhase = phase;

        // Perform phase-specific setup, e.g., spawn enemies, change music, update UI, etc.
        switch (currentPhase)
        {
            case 0:
                // Phase 0 setup
                break;
            case 1:
                // Phase 1 setup
                break;
            // Add more cases for other phases as needed
        }
    }
}
