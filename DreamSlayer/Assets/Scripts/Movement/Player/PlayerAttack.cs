using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FMOD.Studio;
using FMODUnity;

public class PlayerAttack : MonoBehaviour
{
    public Image attackIndicator; // Reference to the UI image.
    public float attackDamage = 10.0f;
    public LayerMask enemyLayer;
    public float attackRange = 1.0f;
    [field: SerializeField] public EventReference attackSoundEvent {get; private set; }

    void Start()
    {
        // Start with the attack indicator image invisible.
        attackIndicator.enabled = false;
    }

    public void PerformAttack()
    {
        if (!attackSoundEvent.IsNull)
        {
            EventInstance eventInstance = RuntimeManager.CreateInstance(attackSoundEvent);
            eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform)); // Set 3D position.
            eventInstance.start();

            // Release the FMOD event instance when it's no longer needed.
            eventInstance.release();
        }

        // Make the attack indicator image visible.
        attackIndicator.enabled = true;

        // Check for collisions with enemies.
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer); // Adjust "attackRange" and "enemyLayer" as needed.

        foreach (Collider2D enemy in hitEnemies)
        {
            // You can implement enemy health and damage handling here.
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }

        // Hide the image after a short delay.
        StartCoroutine(HideAttackIndicator());
    }

    IEnumerator HideAttackIndicator()
    {
        yield return new WaitForSeconds(0.5f); // Half a second duration.
        attackIndicator.enabled = false;
    }
}
