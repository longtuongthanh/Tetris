using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownController : TetrisController
{
    float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var data = app.gameData;
        if (data.gameOver)
            return;
            //data.ResetData();
        if (data.paused)
            return;
        if (countdown <= 0)
        {
            countdown += data.dropstep;
            PushDown();
            app.NotifyBoardChanged();
        }
        countdown -= Time.deltaTime;
    }

    public bool ClearRow(GameData data)
    {
        List<List<Color?>> grid = data.grid;

        int rowCount = 0;
        for (int i = 0; i < grid.Count; i++)
            if (!grid[i].Any(item => item == null))
            {
                data.ClearRow(i);
                rowCount++;
                i--;
            }
        int score = 0;
        if (rowCount > 0)
        {
            if (rowCount <= 4)
                score = ScoreForRow[rowCount - 1] * app.gameData.level;
            else
            {
                score = ScoreForRow[3] * app.gameData.level;
                Debug.LogError("Too many rows cleared at once (" + rowCount + "). Cheat detected.");
            }
            app.gameData.score += score;
            app.gameData.lines += rowCount;
        }

        return rowCount != 0;
    }

    public void PushDown()
    {
        GameData data = app.gameData;
        TetrisTile tile = data.tile;

        if (!Move(data, 0, -1))
        {
            List<List<Color?>> grid = data.grid;

            for (int i = 0; i < 4; i++)
            {
                int x = data.tileOffsetX + tile.coordX[i];
                int y = data.tileOffsetY + tile.coordY[i];

                if (IsCoordInBound(x, y) && (grid[y][x] == null))
                    grid[y][x] = TetrisTile.tileColor[tile.type];
                else
                {
                    app.gameData.gameOver = true;
                    app.NotifyGameOver();
                    //SceneManager.LoadScene("MenuScene");
                }
            }

            bool hasClearedRow = ClearRow(data);
            if (hasClearedRow)
                data.SpeedUp();

            data.GetNewTetrisTile();
        }
    }
}
