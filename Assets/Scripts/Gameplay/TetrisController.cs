using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : TetrisBehaviour
{
    public bool Move(GameData data, int offsetX, int offsetY)
    {
        TetrisTile tile = data.tile;
        int x = data.tileOffsetX + offsetX;
        int y = data.tileOffsetY + offsetY;
        if (CheckFit(data.grid, tile, x, y))
        {
            data.tileOffsetX += offsetX;
            data.tileOffsetY += offsetY;

            data.kickX = 0;

            return true;
        }
        return false;
    }

    public bool RotateWithKick(GameData data, bool isLeftRotation)
    {
        TetrisTile tile = (data.tile.Clone() as TetrisTile?).Value;
        if (isLeftRotation)
            tile.RotateUpToLeft();
        else
            tile.RotateUpToRight();
        int x = data.tileOffsetX - data.kickX;
        int y = data.tileOffsetY - data.kickY;
        if (CheckFit(data.grid, tile, x, y))
        {
            data.tile = tile;
            data.tileOffsetX = x;
            data.tileOffsetY = y;
            data.ResetKick();
            return true;
        }
        if (CheckFit(data.grid, tile, x + 1, y))
        {
            data.tile = tile;
            data.tileOffsetX = x + 1;
            data.tileOffsetY = y;
            data.ResetKick();
            data.kickX = 1;
            return true;
        }
        if (CheckFit(data.grid, tile, x - 1, y))
        {
            data.tile = tile;
            data.tileOffsetX = x - 1;
            data.tileOffsetY = y;
            data.ResetKick();
            data.kickX = -1;
            return true;
        }
        if (CheckFit(data.grid, tile, x, y + 1))
        {
            data.tile = tile;
            data.tileOffsetX = x;
            data.tileOffsetY = y + 1;
            data.ResetKick();
            data.kickY = 1;
            return true;
        }
        return false;
    }

    public bool CheckFit(List<List<Color?>> grid, TetrisTile tile, int coordX, int coordY)
    {
        for (int i = 0; i < 4; i++)
        {
            int x = tile.coordX[i] + coordX;
            int y = tile.coordY[i] + coordY;
            if (!(0 <= x && x < maxX && 0 <= y) ||          // If not in bound
                ((y < maxY) && grid[y][x] != null))      // or tile occupied
                return false;
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
