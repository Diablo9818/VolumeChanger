using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _volumeName;

    public void ChangeVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(_volumeName, Mathf.Log10(volume) * 20);

    }
}
