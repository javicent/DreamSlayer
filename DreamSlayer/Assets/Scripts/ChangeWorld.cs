using UnityEngine;

public class ChangeWorld : MonoBehaviour
{
    public GameObject objectToCollideWith;
    public GameObject prefabToMakeInvisible;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger entered by player.");
            if (objectToCollideWith != null)
            {
                Debug.Log("Collided with: " + objectToCollideWith.name);
                // Set the prefab to be invisible
                prefabToMakeInvisible.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Object to collide with is not assigned.");
            }
        }
    }

}
