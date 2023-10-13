using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f; // Default magnitude
    private float dampingSpeed = 1.0f;

    void Start()
    {
        originalPosition = transform.position; // Store the original camera position
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPosition; // Reset the camera to its original position
        }
    }

    public void Shake(float duration, float magnitude)
    {
        originalPosition = transform.position; // Store the original camera position
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }
}
