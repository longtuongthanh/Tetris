using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisTile : MonoBehaviour
{
    public int[] coordX;
    public int[] coordY;
    public TetrisTileType type;
    public TetrisRotation rotation;

    public enum TetrisTileType
    {
        I,
        L,
        revL,
        Z,
        S,
        T,
        O
    }
    public enum TetrisRotation
    {
        Left,
        Right,
        Up,
        Down
    }
    public TetrisTile(TetrisTileType type)
    {
        this.type = type;
        SetRotation(TetrisRotation.Up);
    }

    public void SetRotation(TetrisRotation rotation)
    {
        this.rotation = rotation;
        // TODO
        switch (type)
        {
            case TetrisTileType.I:
                break;
            case TetrisTileType.L:
                break;
            case TetrisTileType.revL:
                break;
            case TetrisTileType.Z:
                break;
            case TetrisTileType.S:
                break;
            case TetrisTileType.T:
                break;
            case TetrisTileType.O:
                break;
        }
    }
}
