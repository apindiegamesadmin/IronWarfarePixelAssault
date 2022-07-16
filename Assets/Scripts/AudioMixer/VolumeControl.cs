using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] float _multiplier = 30f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleSliderValueChanged(float value)
    {
        _audioMixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
    }
}
