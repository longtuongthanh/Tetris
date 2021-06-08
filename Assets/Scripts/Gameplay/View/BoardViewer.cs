using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardViewer : TetrisBehaviour
{
    public Canvas UI;
    public GameObject gameElements;

    public GameObject TilePrefab;

    ViewTile[,] tiles = new ViewTile[maxX, maxY];

    public void BuildBoard(List<List<Color?>> colors)
    {
        for (int i = 0; i < maxX; i++)
            for (int j = 0; j < maxY; j++)
                if (tiles[i, j] == null)
                {
                    GameObject tile = Instantiate(TilePrefab, UI.transform);
                    ViewTile setting = tile.GetComponent<ViewTile>();

                    setting.x = i;
                    setting.y = j;

                    setting.color = colors[j][i];

                    tile.SetActive(true);
                    tiles[i, j] = setting;
                }
                else
                {
                    ViewTile setting = tiles[i, j];

                    setting.x = i;
                    setting.y = j;

                    setting.color = colors[j][i];

                    setting.Initialize();
                }
    }

    public void ChangeTile(int tileChangedX, int tileChangedY, Color? color)
    {
        ViewTile setting = tiles[tileChangedX, tileChangedY];

        setting.x = tileChangedX;
        setting.y = tileChangedY;

        setting.color = color;

        setting.Initialize();
    }
}
