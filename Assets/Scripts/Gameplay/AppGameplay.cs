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
    public HighscoreView highscoreView;
    public ButtonView buttonView;

    private void NotifyToViewBoardChanged(int tileChangedX, int tileChangedY, Color? color)
    {
        boardViewer.ChangeTile(tileChangedX, tileChangedY, color);
    }

    public void NotifyBoardChanged()
    {
        boardController.IdentifyChangeAndNotify();
    }

    public void NotifyBoardDataChanged(List<List<Color?>> previous, List<List<Color?>> now)
    {
        // assumes same dimensions
        for (int i = 0; i < maxX; i++)
            for (int j = 0; j < maxY; j++)
            {
                if (previous[j][i] != now[j][i])
                    NotifyToViewBoardChanged(i, j, now[j][i]);
            }
    }
}
