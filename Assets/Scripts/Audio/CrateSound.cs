using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSound : MonoBehaviour
{
    [SerializeField] AudioClip crateClip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }

    public void PlayCrateSound()
    {
        audioSource.PlayOneShot(crateClip);
    }
}
