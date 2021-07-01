using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardViewer : TetrisBehaviour
{
    public GameObject gameElements;

    public ViewTile TilePrefab;
    public GameObject TileRoot;

    ViewTile[,] tiles = new ViewTile[maxX, maxY];

    public void BuildBoard(List<List<Color?>> colors)
    {
        for (int i = 0; i < maxX; i++)
            for (int j = 0; j < maxY; j++)
                if (tiles[i, j] == null)
                {
                    ViewTile tile = Instantiate(TilePrefab, TileRoot.transform);

                    tile.x = i;
                    tile.y = j;

                    tile.color = colors[j][i];

                    tile.gameObject.SetActive(true);
                    tiles[i, j] = tile;
                }
                else
                {
                    ViewTile tile = tiles[i, j];

                    tile.x = i;
                    tile.y = j;

                    tile.color = colors[j][i];

                    tile.Initialize();
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
