using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private GameObject HP = default;
    private int MAX_HEALTH = 100;
    void Start()
    {
        HP = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("HP ei voi olla negatiivinen");
        }

        this.health -= amount;

        if (health <= 90)
        {
            Debug.Log("HP -10");

            HP.SetActive(true);
        }        

        if (health <= 0)
        {
            Die();
        }
    }


    public void Heal(int amount)
    { // ei käytössä tämän hetkisessä versiossa
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Ei voi olla negastiivista healia");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("Hahmo on kuollut");
        Destroy(gameObject);
    }
}