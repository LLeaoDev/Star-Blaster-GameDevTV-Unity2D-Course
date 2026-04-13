using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [Header("Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFireRate = 0.2f;


    [Header("AI Variables")]
    [SerializeField] float minimunFireRate = 0.2f;
    [SerializeField] float fireRateVariance = 0;
    [SerializeField] bool useAI;


    Coroutine fireCoroutine;
    [HideInInspector] public bool isFiring;
    AudioManager audioManager;

    [System.Obsolete]
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        if (useAI)
        {
            isFiring = true;
        }
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContiniously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContiniously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, quaternion.identity);

            projectile.transform.rotation = transform.rotation;

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.linearVelocity = transform.up * projectileSpeed;

            Destroy(projectile,projectileLifeTime);

            float waitTime = Random.Range(baseFireRate - fireRateVariance, baseFireRate + fireRateVariance);
            waitTime = Mathf.Clamp(waitTime,minimunFireRate,float.MaxValue);

            audioManager.PlayShootingSFX();

            yield return new WaitForSeconds(waitTime);
        }
        
    }

}
