using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownController : TetrisController
{
    float countdown = 0;
    float dropstep = 1f;
    float reductionSpeed = 0.95f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (app.gameData.gameOver)
            return;
        if (countdown <= 0)
        {
            countdown += dropstep;
            PushDown();
            app.NotifyBoardChanged();
        }
        countdown -= Time.deltaTime;
    }

    public void SpeedUp()
    {
        if (app.gameData.level < maxLevel)
        {
            dropstep *= reductionSpeed;
            app.scoreView.flashTextDuration *= reductionSpeed;
            app.gameData.level++;
        }
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
        uint score = 0;
        if (rowCount > 0)
        {
            if (rowCount <= 4)
                score = ScoreForRow[rowCount - 1] * app.gameData.level;
            else
            {
                score = ScoreForRow[3] * app.gameData.level;
                Debug.LogError("Too many rows cleared at once (" + rowCount + "). Cheat detected.");
            }
            app.scoreView.AddScore(score);
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

                if (IsCoordInBound(x, y))
                    if (grid[y][x] == null)
                        grid[y][x] = TetrisTile.tileColor[tile.type];
                    else
                    {
                        app.gameData.gameOver = true;
                        //SceneManager.LoadScene("MenuScene");
                    }
                else
                    Debug.LogError("tetris piece not in bound.");
            }

            bool hasClearedRow = ClearRow(data);
            if (hasClearedRow)
                SpeedUp();

            data.GetNewTetrisTile();
        }
    }
}
