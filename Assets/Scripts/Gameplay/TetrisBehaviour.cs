using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBehaviour : MonoBehaviour
{
    protected AppGameplay app = AppGameplay.Instance;

    protected const int maxX = 11;
    protected const int maxY = 20;
    protected bool IsCoordInBound(int x, int y)
        => 0 <= x && x < maxX && 0 <= y && y < maxY; 
}
