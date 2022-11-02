using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip healthClip, bulletPowerupClip, shieldPowerupClip, homingMissileClip, speedPowerUpClip, lifePowerUpClip;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayHealthClip()
    {
        audioSource.volume = 0.34f;
        audioSource.PlayOneShot(healthClip);
    }

    public void PlayBulletPowerupClip()
    {
        audioSource.volume = 0.34f;
        audioSource.PlayOneShot(bulletPowerupClip);
    }

    public void PlayShieldPowerupClip()
    {
        audioSource.volume = 0.28f;
        audioSource.PlayOneShot(shieldPowerupClip);
    }

    public void PlayHomingMissileClip()
    {
        audioSource.volume = 0.34f;
        audioSource.PlayOneShot(homingMissileClip);
    }

    public void PlaySpeedUpClip()
    {
        audioSource.volume = 0.23f;
        audioSource.PlayOneShot(speedPowerUpClip);
    }

    public void PlayLifePowerUpClip()
    {
        audioSource.PlayOneShot(lifePowerUpClip);
    }
}
