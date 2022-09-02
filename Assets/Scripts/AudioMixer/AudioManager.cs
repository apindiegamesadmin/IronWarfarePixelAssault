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


    public const string MASTER_VOLUME_KEY = "MasterVolumeKey";
    public const string MUSIC_VOLUME_KEY = "MusicVolumeKey";
    public const string SFX_VOLUME_KEY = "SFXVolumeKey";

    void Awake()
    {
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
        backgroundMusic.clip = mainBgMusic;
        backgroundMusic.Play();

        LoadVolume();
    }

    void LoadVolume()
    {
        float masterVolumueFloat = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1f);
        float musicVolumueFloat = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        float sfxVolumueFloat = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);

        _mixer.SetFloat(VolumeSettings.MASTER_VOLUME, Mathf.Log10(masterVolumueFloat) * 20);
        _mixer.SetFloat(VolumeSettings.MUSIC_VOLUME, Mathf.Log10(musicVolumueFloat) * 20);
        _mixer.SetFloat(VolumeSettings.SFX_VOLUME, Mathf.Log10(sfxVolumueFloat) * 20);
    }

    public void ChangeBackgroundMusic()
    {
        // if (SceneManager.GetActiveScene().buildIndex == 0)
        // {
        //     backgroundMusic.clip = mainBgMusic;
        //     backgroundMusic.Play();
        // }
        // else if (SceneManager.GetActiveScene().buildIndex == 1)
        // {
        //     backgroundMusic.clip = mission1BgMusic;
        //     backgroundMusic.Play();
        // }

        StartCoroutine(WaitBackgroundMusic());
    }

    IEnumerator WaitBackgroundMusic()
    {
        yield return new WaitForSeconds(2);
        backgroundMusic.clip = mission1BgMusic;
        backgroundMusic.Play();
    }
}
