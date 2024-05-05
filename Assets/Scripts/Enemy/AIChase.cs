using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float chaseDistance = 10f;

    private float distance;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Debug.Log("Distance: " + distance);

        if (distance >= -chaseDistance && distance <= chaseDistance)
        {
            chasePlayer();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void chasePlayer()
    {
        animator.SetBool("isRunning", true);
        Vector2 direction = player.transform.position - transform.position;

        // Move Towards the player
        Vector2 destinationVector = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.position = new Vector3(destinationVector.x, transform.position.y, transform.position.z);
        spriteRenderer.flipX = direction.x < 0;
    }
}
