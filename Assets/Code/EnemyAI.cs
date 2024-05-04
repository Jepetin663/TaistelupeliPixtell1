using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform target; // Reference to the player's transform

    private void Update()
    {
        if (target != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = target.position - transform.position;
            direction.Normalize(); // Normalize to get a unit vector

            // Move towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
