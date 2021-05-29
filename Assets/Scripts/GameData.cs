using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Color32[,] grid = new Color32[11, 20];
    public int Score;

    public int[] pieceX = new int[4];
    public int[] pieceY = new int[4];
}
