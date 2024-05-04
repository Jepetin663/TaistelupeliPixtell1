/**1.Create an empty GameObject in your Unity scene.
2.Attach the HealthSystem script to the GameObject.
3.Create a UI Text element in your Canvas for displaying the health.
4.Link the UI Text element to the healthText field in the inspector.
5.Call the TakeDamage() method whenever a character takes damage in your game.**/






using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Text healthText; // Reference to UI text to display health

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement what happens when the character dies
        Debug.Log("Player died!");
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
