using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropdownController : TetrisController
{
    float countdown = 0;
    float dropstep = 2;
    float reductionSpeed = 0.95f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        dropstep *= reductionSpeed;
    }

    public void PushDown()
    {
        GameData data = app.gameData;
        TetrisTile tile = data.tile;

        if (!Move(data, 0, -1))
        {
            var grid = data.grid;

            for (int i = 0; i < 4; i++)
            {
                int x = data.tileOffsetX + tile.coordX[i];
                int y = data.tileOffsetY + tile.coordY[i];

                if (IsCoordInBound(x, y))
                    if (grid[y][x] == null)
                        grid[y][x] = TetrisTile.tileColor[tile.type];
                    else
                        ;// Lose the game
                else
                    Debug.LogError("tetris piece not in bound.");
            }

            bool hasClearedRow = false;
            for (int i = 0; i < grid.Count; i++)
                if (!grid[i].Any(item => item == null))
                {
                    data.ClearRow(i);
                    hasClearedRow = true;
                }
            if (hasClearedRow)
                SpeedUp();

            data.GetNewTetrisTile();
        }
    }
}
