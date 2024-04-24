using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _volumeName;

    private Slider _volumeSlider;
    private int _volumeFactor = 20;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }
    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(_volumeName, Mathf.Log10(volume) * _volumeFactor);

    }
}
