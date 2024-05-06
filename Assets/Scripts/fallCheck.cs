using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallCheck : MonoBehaviour
{
    HealthDamageManager healthDamageManager;
    // Start is called before the first frame update
    private void Awake()
    {
        healthDamageManager = GameObject.FindWithTag("Player").GetComponent<HealthDamageManager>();
        //_fireParticle = fireFX.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthDamageManager.takeDamage(9999999999);
            Debug.Log("ME MATASTEEE!!");
            //animator.SetTrigger("FireOn");
            //GameObject obj = Instantiate(fireFX, firePoint.position, Quaternion.Euler(-90, 0, 0));
            //Destroy(obj, 4);
        }
    }
}
