/*KV^*/


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