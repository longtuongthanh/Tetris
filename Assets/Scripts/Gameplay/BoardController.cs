using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : TetrisController
{
    List<List<Color?>> previousBoard;
    List<List<Color?>> currentBoard;

    private void Awake()
    {
        previousBoard = app.gameData.GridClone();
        app.boardViewer.BuildBoard(previousBoard);
    }

    public void IdentifyChangeAndNotify()
    {
        GameData gameData = app.gameData;

        currentBoard = gameData.GridClone();

        TetrisTile tile = gameData.tile;
        int coordX = gameData.tileOffsetX;
        int coordY = gameData.tileOffsetY;
        for (int i = 0; i < 4; i++) 
        {
            int x = tile.coordX[i] + coordX;
            int y = tile.coordY[i] + coordY;
            if (IsCoordInBound(x, y))
                currentBoard[y][x] = TetrisTile.tileColor[tile.type];
        }

        app.NotifyBoardDataChanged(previousBoard, currentBoard);

        previousBoard = currentBoard;
    }
}
