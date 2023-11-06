using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Transform enemyTransform;  // Reference to the enemy's transform
    public float followSpeed = 5.0f; // Adjust the speed at which the camera follows

    private Camera mainCamera;
    private Vector3 originalCameraPosition;
    private bool isFocusingOnEnemy = false;

    private void Start()
    {
        mainCamera = Camera.main;
        originalCameraPosition = mainCamera.transform.position;
    }

    private void Update()
    {
        if (isFocusingOnEnemy)
        {
            // Set the camera's position to focus on the enemy without looking at it
            mainCamera.transform.position = enemyTransform.position + new Vector3(0, 0, -10); // You may need to adjust the z position if necessary
        }
        else
        {
            // Follow the player
            if (playerTransform != null)
            {
                Vector3 targetPosition = playerTransform.position + new Vector3(0, 1, -10); // Adjust the z position as needed
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
    }

    public void SetEnemyToFocusOn(Transform enemy)
    {
        enemyTransform = enemy;
        isFocusingOnEnemy = true;
    }

    public void StopFocusingOnEnemy()
    {
        enemyTransform = null;
        isFocusingOnEnemy = false;
    }

    public void SetPlayerToFollow(Transform player)
    {
        playerTransform = player;
    }

    public void StopFollowingPlayer()
    {
        playerTransform = null;
    }
}
