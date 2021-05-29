using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting
{
    private float masterVolume;
    private float sfxVolume;
    private float musicVolume;

    public float MasterVolume
    {
        get => masterVolume; set
        {
            masterVolume = value;
            PlayerPrefs.SetFloat("MasterVolume", value);
        }
    }
    public float SFX_Volume
    {
        get => sfxVolume; set
        {
            sfxVolume = value;
            PlayerPrefs.SetFloat("SFX_Volume", value);
        }
    }
    public float MusicVolume
    {
        get => musicVolume; set
        {
            musicVolume = value;
            PlayerPrefs.SetFloat("MusicVolume", value);
        }
    }
    public SoundSetting()
    {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 80);
        sfxVolume = PlayerPrefs.GetFloat("SFX_Volume", 80);
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 80);
    }
}