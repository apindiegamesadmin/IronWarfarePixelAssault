using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] Slider _masterSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _sfxSlider;

    public const string MASTER_VOLUME = "MasterVolume";
    public const string MUSIC_VOLUME = "MusicVolume";
    public const string SFX_VOLUME = "SFXVolume";

    void Awake()
    {
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        _masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_VOLUME_KEY, 1f);
        _musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_VOLUME_KEY, 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_VOLUME_KEY, 1f);
    }

    void SetMasterVolume(float value)
    {
        _audioMixer.SetFloat(MASTER_VOLUME, Mathf.Log10(value) * 20);
    }

    void SetMusicVolume(float value)
    {
        _audioMixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat(SFX_VOLUME, Mathf.Log10(value) * 20);
    }


    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MASTER_VOLUME_KEY, _masterSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_VOLUME_KEY, _musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_VOLUME_KEY, _sfxSlider.value);
    }



    // public void SaveVolumeSettings()
    // {
    //     PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, _masterSlider.value);
    //     PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, _musicSlider.value);
    //     PlayerPrefs.SetFloat(SFX_VOLUME_KEY, _sfxSlider.value);
    // }

}
