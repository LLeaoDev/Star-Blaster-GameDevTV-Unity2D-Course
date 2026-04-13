using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] ParticleSystem hitParticle;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;

    [System.Obsolete]
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitParticles();
            damageDealer.Hit();

            if (applyCameraShake)
            {
                cameraShake.Play();
            }
        }

    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=  0) 
        {
            Destroy(gameObject);
        }
    }

    void PlayHitParticles()
    {
        if(hitParticle != null)
        {
            audioManager.PlayDamageSFX();
            ParticleSystem particles = Instantiate(hitParticle,transform.position,Quaternion.identity);
            Destroy(particles, particles.main.duration + particles.main.startLifetime.constantMax);
        }
    }


}
