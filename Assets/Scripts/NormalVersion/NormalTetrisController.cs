using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalTetrisController : MonoBehaviour
{
    public int scorePerBlock;
    public int scorePerLine;
    public int currentScore;
    public int currentLine;
    public Text scoreText;
    public Text lineText;
    public static NormalTetrisController Instance;
    private void Awake() 
    {
        if (Instance == null) Instance =  this;
        InitGame();
    }

    public void InitGame()
    {
        currentScore = 0;
        currentLine = 0;
        UpdateUI();
    }

    public void AddBlockScore()
    {
        currentScore += scorePerBlock;
        UpdateUI();
    }

    public void AddLineScore()
    {
        currentScore += scorePerLine;
        currentLine++;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = currentScore.ToString();
        lineText.text = currentLine.ToString();
    }
}
