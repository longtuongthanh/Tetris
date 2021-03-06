using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : TetrisBehaviour
{
    public Text scoreText;
    public Text flashText;
    public Text levelText;
    public Text lineText;
    public float flashTextCountdown = 0f;
    int score = 0;

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = this.score.ToString();
    }

    private void SetFlashTest(int addedScore)
    {
        flashTextCountdown = app.gameData.flashTextDuration;
        flashText.text = "+ " + addedScore.ToString();
    }

    public void AddScore(int addedScore)
    {
        this.score += addedScore;
        if (addedScore > 0)
            SetFlashTest(addedScore);
        scoreText.text = this.score.ToString();
    }

    private void Update()
    {
        if (flashTextCountdown > 0)
            flashTextCountdown -= Time.deltaTime;
        else
            flashTextCountdown = 0;

        Color temp = flashText.color;
        temp.a = flashTextCountdown / app.gameData.flashTextDuration;
        flashText.color = temp;

        if (score != app.gameData.score)
            AddScore(app.gameData.score - score);
        
        int line = app.gameData.lines;
        if (line > 99)
            lineText.text = "99";
        else
            lineText.text = (line / 10).ToString() + (line % 10).ToString();

        levelText.text = app.gameData.level.ToString();
    }
}
