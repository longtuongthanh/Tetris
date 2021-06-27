using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreView : MonoBehaviour
{
    public Text scoreText;
    public Text flashText;
    public float flashTextDuration = 2f;
    public float flashTextCountdown = 0f;
    int score = 0;

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

    public void SetFlashTest(uint addedScore)
    {
        flashTextCountdown = flashTextDuration;
        //flashText.text = "+ " + addedScore.ToString();
    }

    public void AddScore(uint addedScore)
    {
        this.score += (int)addedScore;
        SetFlashTest(addedScore);
        scoreText.text = this.score.ToString();
    }

    private void Update()
    {
        if (flashTextCountdown > 0)
            flashTextCountdown -= Time.deltaTime;
        else
            flashTextCountdown = 0;
        //Color temp = flashText.color;
        //temp.a = flashTextCountdown / flashTextDuration;
        //flashText.color = temp;
    }
}
