using System;
using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 2;
    [SerializeField] float shakeMagnetude = .5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0;
        
        while(timeElapsed < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnetude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
        transform.position = initialPosition;
    }
}
