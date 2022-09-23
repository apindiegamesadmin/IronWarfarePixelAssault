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

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();

        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        _masterSlider.value = player.master;
        _musicSlider.value = player.music;
        _sfxSlider.value = player.sound;
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
        player.master = _masterSlider.value;
        player.music = _musicSlider.value;
        player.sound = _sfxSlider.value;
    }
}
