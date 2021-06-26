using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaData : MonoBehaviour
{
    public static MetaData instance;

    MetaData()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        soundSetting = new SoundSetting();
    }

    public SoundSetting soundSetting;
    private int highscore;

    public int Highscore
    {
        get => highscore; set
        {
            highscore = value;
            PlayerPrefs.SetInt("HighScore", value);
        }
    }
}
