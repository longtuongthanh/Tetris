using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : TetrisBehaviour
{
    public Button LeftButton;
    public Button RightButton;  
    public Button RightRotateButton;
    public Button DownButton;

    public Button PauseButton;
    public GameObject PausePanel;
    public Button RestartButton;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        LeftButton.onClick.AddListener(app.playerController.MoveLeft);
        RightButton.onClick.AddListener(app.playerController.MoveRight);
        PauseButton.onClick.AddListener(app.playerController.OnPauseClick);
        RestartButton.onClick.AddListener(app.playerController.OnRetryClick);
        RightRotateButton.onClick.AddListener(app.playerController.RotateRight);
        DownButton.onClick.AddListener(app.playerController.MoveDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
