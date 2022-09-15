using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSound : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip healthClip, bulletPowerupClip, shieldPowerupClip, homingMissileClip, speedPowerUpClip;

    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayHealthClip()
    {
        _audioSource.PlayOneShot(healthClip);
    }

    public void PlayBulletPowerupClip()
    {
        _audioSource.PlayOneShot(bulletPowerupClip);
    }

    public void PlayShieldPowerupClip()
    {
        _audioSource.PlayOneShot(shieldPowerupClip);
    }

    public void PlayHomingMissileClip()
    {
        _audioSource.PlayOneShot(homingMissileClip);
    }

    public void PlaySpeedUpClip()
    {
        _audioSource.PlayOneShot(speedPowerUpClip);
    }
}
