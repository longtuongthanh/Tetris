using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBehaviour : MonoBehaviour
{
    protected AppGameplay app = AppGameplay.Instance;

    protected const int maxX = 9;
    protected const int maxY = 17;
    protected bool IsCoordInBound(int x, int y)
        => 0 <= x && x < maxX && 0 <= y && y < maxY;

    public static readonly List<int> ScoreForRow = new List<int> { 100, 300, 500, 800 };
    public const int maxLevel = 20;
}
