using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer _mixer;

    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioClip mainBgMusic;
    [SerializeField] AudioClip mission1BgMusic;
    [SerializeField] AudioClip mission2BgMusic;
    [SerializeField] AudioClip mission3BgMusic;
    [SerializeField] AudioClip mission4BgMusic;
    [SerializeField] AudioClip mission5BgMusic;

    [SerializeField] AudioClip mission1BossFightBgMusic;
    [SerializeField] AudioClip mission2BossFightBgMusic;
    [SerializeField] AudioClip mission3BossFightBgMusic;
    [SerializeField] AudioClip mission4BossFightBgMusic;
    [SerializeField] AudioClip mission5BossFightBgMusic;


    public const string MASTER_VOLUME_KEY = "MasterVolumeKey";
    public const string MUSIC_VOLUME_KEY = "MusicVolumeKey";
    public const string SFX_VOLUME_KEY = "SFXVolumeKey";

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadVolume();
    }

    void LoadVolume()
    {
        float masterVolumueFloat = player.master;
        float musicVolumueFloat = player.music;
        float sfxVolumueFloat = player.sound;

        _mixer.SetFloat(VolumeSettings.MASTER_VOLUME, Mathf.Log10(masterVolumueFloat) * 20);
        _mixer.SetFloat(VolumeSettings.MUSIC_VOLUME, Mathf.Log10(musicVolumueFloat) * 20);
        _mixer.SetFloat(VolumeSettings.SFX_VOLUME, Mathf.Log10(sfxVolumueFloat) * 20);
    }

    public void PlayMainMenuBGSound()
    {
        backgroundMusic.clip = mainBgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
    }

    public void PlayMission1BGSound()
    {
        backgroundMusic.clip = mission1BgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.4f;
    }

    public void PlayMission2BGSound()
    {
        backgroundMusic.clip = mission2BgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
    }

    public void PlayMission3BGSound()
    {
        backgroundMusic.clip = mission3BgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
    }

    public void PlayMission4BGSound()
    {
        backgroundMusic.clip = mission4BgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
    }

    public void PlayMission5BGSound()
    {
        backgroundMusic.clip = mission5BgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 0.6f;
    }

    IEnumerator WaitBackgroundMusic()
    {
        yield return new WaitForSeconds(2);
        backgroundMusic.clip = mission1BgMusic;
        backgroundMusic.Play();
    }

    IEnumerator DelayLevel2Music()
    {
        yield return new WaitForSeconds(2);
        backgroundMusic.clip = mission2BgMusic;
        backgroundMusic.Play();
    }

    // Boss fight background music field
    public void PlayMission1BossFightSound()
    {
        backgroundMusic.clip = mission1BossFightBgMusic;
        backgroundMusic.Play();
        backgroundMusic.volume = 1f;
    }

    public void PlayMission2BossFightSound()
    {
        backgroundMusic.clip = mission2BossFightBgMusic;
        backgroundMusic.Play();
    }

    public void PlayMission3BossFightSound()
    {
        backgroundMusic.clip = mission3BossFightBgMusic;
        backgroundMusic.Play();
    }

    public void PlayMission4BossFightSound()
    {
        backgroundMusic.clip = mission4BossFightBgMusic;
        backgroundMusic.Play();
    }

    public void PlayMission5BossFightSound()
    {
        backgroundMusic.clip = mission5BossFightBgMusic;
        backgroundMusic.Play();
    }
}
