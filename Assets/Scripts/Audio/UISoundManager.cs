using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clickAudio;

    public void PlayClickSound()
    {
        audioSource.clip = clickAudio;
        audioSource.Play();
    }
}
