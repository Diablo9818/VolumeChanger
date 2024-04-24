using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private bool _isPlaying = true;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.Play();
            _isPlaying = true;
        }
    }

    private void Stop()
    {
        _audioSource.Stop();
        _isPlaying = false;
    }
}
