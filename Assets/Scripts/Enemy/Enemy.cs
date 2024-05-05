using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float currentHealth, maxHealth = 3f;
    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Let's attack");
            Attack();
        }
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            // TODO: Call TakeDamage function of the player
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        animator.SetTrigger("TakeDamage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // ??? Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
