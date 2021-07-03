using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipEnum
{
    Music,

    Click,
    Congrat,
    Lose,
}

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public List<AudioClipEnum> enumOrder;
    public Dictionary<AudioClipEnum, AudioSource> audioSources = new Dictionary<AudioClipEnum, AudioSource>();

    public AudioSource sourcePrefab;

    private static SoundManager ins;
    public static SoundManager Ins { get => ins; }
    
    SoundManager()
    {
        ins = this;
        enumOrder = new List<AudioClipEnum>();
        foreach (AudioClipEnum item in Enum.GetValues(typeof(AudioClipEnum)))
        {
            enumOrder.Add(item);
        }
    }

    bool CheckAudioAvailable(AudioClipEnum audioClip)
    {
        if (!gameObject.activeInHierarchy)
            return false;
        if (audioSources[audioClip] == null)
        {
            Debug.LogWarning("Audio Clip " + audioClip + " is not available.");
            return false;
        }
        return true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        for (int i = 0; i < audioClips.Count; i++)
        {
            var item = audioClips[i];
            if (item != null)
            {
                var temp = audioSources[enumOrder[i]] = Instantiate(sourcePrefab, transform);
                temp.clip = item;
            }
        }
    }

    public void Play(int audioClip)
    {
        Play((AudioClipEnum)audioClip);
    }

    public void Play(AudioClipEnum audioClip, int numberOfTimes = 1)
    {
        if (!CheckAudioAvailable(audioClip))
            return;

        var temp = audioSources[audioClip];
        if (temp.isPlaying)
        {
            Debug.Log("Audio Clip " + audioClip + " is already playing.");
            return;
        }
        for (int i = 0; i < numberOfTimes; i++)
        {
            if (i > 0)
                temp.PlayDelayed(temp.clip.length * i);
            else
                temp.Play();
        }
    }

    public void PlayLooped(AudioClipEnum audioClip)
    {
        if (!CheckAudioAvailable(audioClip))
            return;
        var temp = audioSources[audioClip];
        temp.loop = true;
        if (!temp.isPlaying)
            temp.Play();
    }

    public void StopPlayLooped(AudioClipEnum audioClip)
    {
        if (!CheckAudioAvailable(audioClip))
            return;
        var temp = audioSources[audioClip];
        temp.loop = false;
        if (temp.isPlaying)
            temp.Stop();
    }
}
