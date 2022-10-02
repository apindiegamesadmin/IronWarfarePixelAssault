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

        _masterSlider.value = Player.instance.master;
        _musicSlider.value = Player.instance.music;
        _sfxSlider.value = Player.instance.sound;
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
        Player.instance.master = _masterSlider.value;
        Player.instance.music = _musicSlider.value;
        Player.instance.sound = _sfxSlider.value;

        Player.instance.SavePlayerData();
    }
}
