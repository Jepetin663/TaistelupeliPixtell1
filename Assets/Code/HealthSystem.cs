/**1.Create an empty GameObject in your Unity scene.
2.Attach the HealthSystem script to the GameObject.
3.Create a UI Text element in your Canvas for displaying the health.
4.Link the UI Text element to the healthText field in the inspector.
5.Call the TakeDamage() method whenever a character takes damage in your game.**/






using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth_ = 100;
    public int currentHealth_;

    public Text healthText; // Reference to UI text to display health

    private void Start()
    {
        currentHealth_ = maxHealth_;
        UpdateHealthUI_();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth_ -= damageAmount;
        currentHealth_ = Mathf.Clamp(currentHealth_, 0, maxHealth_); // Ensure health doesn't go below 0 or above maxHealth
        UpdateHealthUI_();

        if (currentHealth_ <= 0)
        {
            Die_();
        }
    }

    void Die_()
    {
        // Implement what happens when the character dies
        Debug.Log("Player died!");
        gameObject.SetActive(false);
    }

    void UpdateHealthUI_()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth_.ToString();
        }
    }
}