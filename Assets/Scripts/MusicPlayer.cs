using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button)), RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;


    private Button _button;
    private int _maxVolume = 0;
    private int _minVolume = -80;

    private bool _isPlaying = true;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        if (_isPlaying)
        {
            Stop();
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat("MyExposedParam", _maxVolume);
            _isPlaying = true;
        }
    }

    private void Stop()
    {
        _audioMixerGroup.audioMixer.SetFloat("MyExposedParam", _minVolume);
        _isPlaying = false;
    }
}
