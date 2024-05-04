using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healtsystem_oikea : MonoBehaviour
{
    public int maxHits = 10;
    private int currentHits;

    private void Start()
    {
        currentHits = maxHits;
    }

    public void TakeHit()
    {
        currentHits--;

        if (currentHits <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement what happens when the character dies
        Debug.Log("Player died!");
    }


}
