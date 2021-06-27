using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : TetrisBehaviour
{
    public List<List<Color?>> grid;
    public int score;

    private TetrisTile? _tile;

    public int tileOffsetX;
    public int tileOffsetY;

    public int kickX = 0;
    public int kickY = 0;

    public uint level = 1;
    public bool gameOver = false;

    public TetrisTile tile
    {
        get {
            if (_tile == null)
                _tile = TetrisTile.GetNewTetrisTile();
            return _tile.Value; 
        }
        set => _tile = value;
    }

    public GameData()
    {
        tileOffsetX = maxX / 2;
        tileOffsetY = maxY - 2;
        grid = new List<List<Color?>>();
        for (int i = 0; i < maxY; i++)
            grid.Add(NewGridRow());
    }

    public void ResetKick()
    {
        kickX = 0;
        kickY = 0;
    }

    public void GetNewTetrisTile()
    {
        _tile = TetrisTile.GetNewTetrisTile();
        tileOffsetX = maxX / 2;
        tileOffsetY = maxY - 2;
        ResetKick();
    }

    public void ClearRow(int index)
    {
        grid.RemoveAt(index);
        grid.Add(NewGridRow());
    }

    private List<Color?> NewGridRow()
    {
        List<Color?> row = new List<Color?>();
        for (int j = 0; j < maxX; j++)
            row.Add(null);
        return row;
    }
    
    public List<List<Color?>> GridClone()
    {
        return new List<List<Color?>>(
            grid.Select(
                item => new List<Color?>(item)
            )
        );
    }
}
