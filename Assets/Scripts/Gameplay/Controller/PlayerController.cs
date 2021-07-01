using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TetrisController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (app.gameData.gameOver)
            return;

        bool changed = false;
        GameData gameData = app.gameData;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changed = true;
            Move(gameData, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changed = true;
            Move(gameData, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changed = true;
            Move(gameData, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changed = true;
            RotateWithKick(gameData, true);
        }
        if (changed)
            app.NotifyBoardChanged();
    }


    public void OnRetryClick()
    {
        var gameOverPanel = app.buttonView.gameOverPanel;
        gameOverPanel.SetActive(!gameOverPanel.activeSelf);
        app.gameData.ResetData();
    }
    public void OnPauseClick()
    {
        var pausePanel = app.buttonView.PausePanel;
        pausePanel.SetActive(!pausePanel.activeSelf);
        app.gameData.paused = !app.gameData.paused;
    }
    public void MoveLeft()
    {
        GameData gameData = app.gameData;
        Move(gameData, -1, 0);
        app.NotifyBoardChanged();
    }
    public void MoveRight()
    {
        GameData gameData = app.gameData;
        Move(gameData, 1, 0);
        app.NotifyBoardChanged();
    }
    public void MoveDown()
    {
        GameData gameData = app.gameData;
        while (Move(gameData, 0, -1));
        app.NotifyBoardChanged();
    }
    public void RotateLeft()
    {
        GameData gameData = app.gameData;
        RotateWithKick(gameData, true);
        app.NotifyBoardChanged();
    }
    public void RotateRight()
    {
        GameData gameData = app.gameData;
        RotateWithKick(gameData, false);
        app.NotifyBoardChanged();
    }
}
