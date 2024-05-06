using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform firePoint;
    public Animator animator;
    HealthDamageManager healthDamageManager;
    [SerializeField] private GameObject fireFX;
    private ParticleSystem _fireParticle;

    // Start is called before the first frame update
    private void Awake()
    {
        healthDamageManager = GameObject.FindWithTag("Player").GetComponent<HealthDamageManager>();
        _fireParticle = fireFX.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            healthDamageManager.updateCheckpoint(spawnPoint.position);
            animator.SetTrigger("FireOn");
            GameObject obj = Instantiate(fireFX, firePoint.position , Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 4);
        }
    }
}
