/*Attach this script to the enemy's weapon or collider. When the weapon collides with a player (assuming the player has a HealthSystem component),
 * it will cause damage to the player's health. Make sure the colliders are set up appropriately and tagged if needed for collision detection.^*/


using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(damageAmount);
        }
    }
}