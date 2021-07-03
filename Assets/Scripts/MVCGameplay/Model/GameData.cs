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

    public int level;
    public int lines;
    public float dropstep;
    public float flashTextDuration;
    public float reductionSpeed;

    public bool paused = false;
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
        score = 0;
        lines = 0;
        level = 1;
        dropstep = 1f;
        flashTextDuration = 2f;
        reductionSpeed = 0.95f;
        tileOffsetX = maxX / 2;
        tileOffsetY = maxY - 2;
        grid = new List<List<Color?>>();
        for (int i = 0; i < maxY; i++)
            grid.Add(NewGridRow());
    }
    
    public void SpeedUp()
    {
        if (level < maxLevel)
        {
            dropstep *= reductionSpeed;
            flashTextDuration *= reductionSpeed;
            level++;
        }
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

    public void ResetData()
    {
        score = 0;
        lines = 0;
        level = 1;
        dropstep = 1f;
        reductionSpeed = 0.95f;
        flashTextDuration = 2f;
        gameOver = false;
        paused = false;
        grid = new List<List<Color?>>();
        for (int i = 0; i < maxY; i++)
            grid.Add(NewGridRow());
        TetrisTile.ResetBag();
        GetNewTetrisTile();
    }
}
