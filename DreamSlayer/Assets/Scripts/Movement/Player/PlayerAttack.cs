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
    [field: SerializeField] public EventReference attackSoundEvent { get; private set; }
    public Animator playerAnimator; // Reference to the player's Animator component.
    public string attackAnimationName = "Attack"; // Name of the attack animation trigger parameter.

    private SpriteRenderer playerSpriteRenderer; // Reference to the player's SpriteRenderer.

    void Start()
    {
        // Start with the attack indicator image invisible.
        attackIndicator.enabled = false;

        // Get the SpriteRenderer component from the player.
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null && !enemyHealth.IsDying())
            {
                enemyHealth.TakeDamage(attackDamage);

                // Trigger the attack animation on the player.
                playerAnimator.SetTrigger(attackAnimationName);
            }
        }

        // Mirror the attack indicator if the player sprite is mirrored.
        attackIndicator.rectTransform.localScale = new Vector3(playerSpriteRenderer.flipX ? -1 : 1, 1, 1);

        // Hide the image after a short delay.
        StartCoroutine(HideAttackIndicator());
    }

    IEnumerator HideAttackIndicator()
    {
        yield return new WaitForSeconds(0.5f); // Half a second duration.
        attackIndicator.enabled = false;
    }
}
