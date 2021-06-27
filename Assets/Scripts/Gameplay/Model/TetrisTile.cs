using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TetrisTile: ICloneable
{
    public int[] coordX;
    public int[] coordY;
    public TetrisTileType type;
    public static readonly TetrisTileType[] bag = new TetrisTileType[7] {
        TetrisTileType.I,
        TetrisTileType.L,
        TetrisTileType.O,
        TetrisTileType.J,
        TetrisTileType.S,
        TetrisTileType.T,
        TetrisTileType.Z
    };
    public static List<TetrisTile> currentBag = new List<TetrisTile>();
    public static Dictionary<TetrisTileType, Color> tileColor = new Dictionary<TetrisTileType, Color>
    {
        { TetrisTileType.I, new Color(1,0.5f,1,1) },
        { TetrisTileType.L, new Color(1,0,1,1) },
        { TetrisTileType.O, new Color(1,0,0,1) },
        { TetrisTileType.J, new Color(1,1,0,1) },
        { TetrisTileType.S, new Color(0,1,1,1) },
        { TetrisTileType.T, new Color(0,0,1,1) },
        { TetrisTileType.Z, new Color(0,1,0,1) }
    };

    public enum TetrisTileType
    {
        I,
        L,
        J,
        Z,
        S,
        T,
        O
    }
    
    public TetrisTile(TetrisTileType type)
    {
        this.type = type;
        switch (type)
        {
            case TetrisTileType.I:
                coordX = new int[4] { 0, 0, 0, 0 };
                coordY = new int[4] { -1, 0, 1, 2 };
                break;
            case TetrisTileType.L:
                coordX = new int[4] { 1, 1, 0, -1 };
                coordY = new int[4] { 1, 0, 0, 0 };
                break;
            case TetrisTileType.J:
                coordX = new int[4] { -1, 1, 0, -1 };
                coordY = new int[4] { 1, 0, 0, 0 };
                break;
            case TetrisTileType.Z:
                coordX = new int[4] { -1, 0, 0, 1 };
                coordY = new int[4] { 1, 1, 0, 0 };
                break;
            case TetrisTileType.S:
                coordX = new int[4] { -1, 0, 0, 1 };
                coordY = new int[4] { 0, 0, 1, 1 };
                break;
            case TetrisTileType.T:
                coordX = new int[4] { 0, 1, 0, -1 };
                coordY = new int[4] { 1, 0, 0, 0 };
                break;
            case TetrisTileType.O:
                coordX = new int[4] { 1, 1, 0, 0 };
                coordY = new int[4] { 1, 0, 0, 1 };
                break;
            default:
                throw new KeyNotFoundException();
        }
    }
    public void RotateUpToLeft()
    {
        if (type == TetrisTileType.O)
            return;

        // swap coordX & coordY
        int[] temp = coordX;
        coordX = coordY;
        coordY = temp;

        if (type == TetrisTileType.I)
            return;

        // invert X axis
        for (int i = 0; i < 4; i++)
            coordX[i] = -coordX[i];
    }
    public void RotateUpToRight()
    {
        if (type == TetrisTileType.O) 
            return;

        // swap coordX & coordY
        int[] temp = coordX;
        coordX = coordY;
        coordY = temp;

        if (type == TetrisTileType.I)
            return;

        // invert Y axis
        for (int i = 0; i < 4; i++)
            coordY[i] = -coordY[i];
    }

    public static TetrisTile GetNewTetrisTile()
    {
        if (currentBag.Count <= 0)
        {
            foreach (TetrisTileType item in bag)
            {
                currentBag.Add(new TetrisTile(item));
            }
        }

        int index = UnityEngine.Random.Range(0, currentBag.Count);
        TetrisTile result = currentBag[index];
        currentBag.RemoveAt(index);

        return result;
    }

    public object Clone()
    {
        TetrisTile temp = (MemberwiseClone() as TetrisTile?).Value;
        temp.coordX = temp.coordX.Clone() as int[];
        temp.coordY = temp.coordY.Clone() as int[];
        return temp;
    }
}
