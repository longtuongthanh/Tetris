using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalTetrisController : MonoBehaviour
{
    public int fakeLoop;
    public int scorePerBlock;
    public int scorePerLine;
    public int currentScore;
    public int currentLine;
    public Text scoreText;
    public Text lineText;
    public float fallTime;
    public float fallTimeCount;
    public bool isPauseGame = false;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public BlockComponent currentBlock;
    public Animator LineFxAnimator;
    public static NormalTetrisController Instance;
    private List<int> list;
    private void Awake() 
    {
        if (Instance == null) Instance =  this;
        list = new List<int>();
        InitGame();
    }
    private void Update() 
    {
        for (int i = 0; i<fakeLoop; i++)
        {
            list.Add(1);
        }
        if (!isPauseGame)
        {
            

            fallTimeCount += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentBlock.MoveToEnd();
                fallTimeCount = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentBlock.MoveLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentBlock.MoveRight();
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentBlock.Rotate();
            }

        }    

        if (fallTimeCount > fallTime)
        {
            currentBlock.MoveDown();
            fallTimeCount = 0.0f;
            //currentBlock.mo
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        
    }

    private void CheckLose()
    {
        //var grid = BlockComponent.
    }

    public void InitGame()
    {
        currentScore = 0;
        currentLine = 0;
        fallTimeCount = 0.0f;
        SoundManager.Ins.PlayLooped(AudioClipEnum.Music);
        UpdateUI();
    }
    public void RestartGame()
    {
        currentBlock = null;
        BlockComponent.ClearGrid();
        FindObjectOfType<Spawner>().SpawnNewBlock();
    }
    public void PauseGame()
    {
        isPauseGame = !isPauseGame;
        pausePanel.SetActive(isPauseGame);
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

    public void MoveLeftButton()
    {
        currentBlock?.MoveLeft();
    }

    public void MoveRightButton()
    {
        currentBlock?.MoveRight();
    }

    public void RotateButton()
    {
        currentBlock?.Rotate();
    }

    public void MoveDownToEnd()
    {
        currentBlock.MoveToEnd();
        fallTimeCount = 0.0f;
    }
}
