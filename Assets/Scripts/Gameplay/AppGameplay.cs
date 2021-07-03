using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppGameplay : TetrisBehaviour
{
    public static AppGameplay Instance { get => inst; }
    private static AppGameplay inst;

    AppGameplay()
    {
        inst = this;
    }

    public GameData gameData;
    public PlayerController playerController;
    public BoardController boardController;
    public DropdownController dropdownController;
    public BoardViewer boardViewer;
    public ScoreView scoreView;
    public ButtonView buttonView;
    public SoundManager soundManager;

    public void NotifyBoardChanged()
    {
        boardController.IdentifyChangeAndNotify();
    }

    public void NotifyGameOver()
    {
        buttonView.GameOver();
        soundManager.Play(AudioClipEnum.Lose);
    }
}
