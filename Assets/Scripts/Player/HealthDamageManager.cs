using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamageManager : MonoBehaviour
{
   public Animator animator;
   public PlayerMovement playerMovement;
   public Transform attackPoint;
    public Transform spawnPoint;
   public float attackRange = 0.5f;
   public float attackRate = 2f;
   float nextAttackTime = 0;
    bool isPressed = false;

   Vector2 startPos;

    public float maxHealth = 100f;
    private float health;

    public LayerMask enemyLayers;

    private void Start()
    {
        health = maxHealth;
       startPos = transform.position;
    }

    
    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
          isPressed = true;
            if (Time.time >= nextAttackTime )
            {
                //Debug.Log("The left mouse button is being held down.");
                Attack();
                animator.SetBool("IsPressed", isPressed);
                nextAttackTime = Time.time +1f /attackRate;
            }
        }
        if (Input.GetMouseButtonUp(0)){
            isPressed = false;
            animator.SetBool("IsPressed", isPressed);

        }

        //Debug.Log(isPressed);
        

    }

    public void updateCheckpoint(Vector2 pos)
    {
        spawnPoint.position = pos;
    }

    private void Attack()
    {
        if(health > 0) { 
        animator.SetTrigger("Attack");


        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Un video mah mi gente" + enemy.name);
        }
        }

    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            die();
        }
        else { 
        animator.SetTrigger("Hurt");
        }
        //Debug.Log("AUCH!!");
        //damage animation
    }

    private void die()
    {
        Debug.Log("Huh???");
        animator.SetTrigger("Deadass");
        playerMovement.enabled = false;
        StartCoroutine(respawn(2f));
    }

     IEnumerator respawn(float duration)
    {
        Debug.Log("Watin");
        yield return new WaitForSeconds(duration);
        animator.SetTrigger("WakeUp");
        health = maxHealth;
        playerMovement.enabled = true;
        transform.position = spawnPoint.position;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    
    }
}
