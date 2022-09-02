using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer _mixer;

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
}
