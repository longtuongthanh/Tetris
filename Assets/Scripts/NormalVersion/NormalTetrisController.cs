using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NormalTetrisController : MonoBehaviour
{
    private int fakeLoop = 100;
    public int scorePerBlock;
    public int scorePerLine;
    public int currentScore;
    public int currentLine;
    public Text scoreText;
    public Text lineText;
    public float startFallTime;
    private float currentFallTime;
    private float fallTimeCount;
    public float speedUpTime;
    public float speedUpAmount;
    private float speedUpTimeCount;
    public float limitHoldKey;
    private float limitHoldKeyCount;
    public bool isPauseGame = false;
    public bool isLoseGame = false;
    public bool isAllowSpeedUp = true;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public BlockComponent currentBlock;
    public Animator LineFxAnimator;
    public static NormalTetrisController Instance;
    private List<BlockComponent> blocks;
    private List<int> list;
    private void Awake() 
    {
        if (Instance == null) Instance =  this;
        blocks = new List<BlockComponent>();
        list = new List<int>();
    }
    private void Start() {
        InitGame();
        
    }
    private void Update() 
    {
        if (isLoseGame) return;
        if (!isPauseGame)
        {
            
            fallTimeCount += Time.deltaTime;
            speedUpTimeCount += Time.deltaTime;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                limitHoldKeyCount += Time.deltaTime;
                if (limitHoldKeyCount > limitHoldKey)
                {
                    currentBlock.MoveDown();
                    limitHoldKeyCount = 0.0f;
                    fallTimeCount = 0.0f;
                }
                //fallTimeCount = 0.0f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
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

        if (fallTimeCount > currentFallTime)
        {
            currentBlock.MoveDown();
            fallTimeCount = 0.0f;
            //currentBlock.mo
        }

        if (isAllowSpeedUp)
        {
            if (speedUpTimeCount > speedUpTime)
            {
                currentFallTime -= speedUpAmount;
                speedUpTimeCount = 0.0f;
            }
            isAllowSpeedUp = false;
        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        
    }

    public void InitGame()
    {
        currentScore = 0;
        currentLine = 0;
        fallTimeCount = 0.0f;
        speedUpTimeCount = 0.0f;
        isPauseGame = false;
        isLoseGame = false;
        isAllowSpeedUp = true;
        currentFallTime = startFallTime;
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SoundManager.Ins.PlayLooped(AudioClipEnum.Music);
        UpdateUI();
        FindObjectOfType<Spawner>().SpawnNewBlock();
    }
    public void LoseGame()
    {
        isLoseGame = true;
        gameOverPanel.SetActive(true);
    }
    public void SpawnBlock(BlockComponent block)
    {
        blocks.Add(block);
        currentBlock = block;
        isAllowSpeedUp = true;
    }
    public void RestartGame()
    {
        //currentBlock = null;
        Destroy(currentBlock.gameObject);
        BlockComponent.ClearGrid();
        foreach(var block in blocks)
        {
            Destroy(block.gameObject);
        }
        blocks.Clear();
        InitGame();
        
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
