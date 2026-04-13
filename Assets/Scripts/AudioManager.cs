using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0,1)] float shootingVolume = .5f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0,1)] float damageVolume = .5f;


    public void PlayShootingSFX()
    {
        if(shootingClip != null)
        {
            PlayAudioClip(shootingClip,shootingVolume);
        }
    }

    public void PlayDamageSFX()
    {
        if(damageClip != null)
        {
            PlayAudioClip(damageClip,damageVolume);
        }
    }

    void PlayAudioClip(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
