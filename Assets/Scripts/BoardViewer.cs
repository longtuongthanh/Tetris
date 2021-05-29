using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardViewer : MonoBehaviour
{
    // Coords: [11, 20]
    const int maxX = 11;
    const int maxY = 20;

    public Canvas UI;
    public GameObject gameElements;

    public GameObject TilePrefab;

    ViewTile[,] tiles = new ViewTile[maxX, maxY];

    public void BuildBoard(Color32[,] colors)
    {
        for (int i = 0; i < maxX; i++)
            for (int j = 0; j < maxY; j++)
                if (tiles[i, j] == null)
                {
                    GameObject tile = Instantiate(TilePrefab, UI.transform);
                    ViewTile setting = tile.GetComponent<ViewTile>();

                    setting.x = i;
                    setting.y = j;

                    setting.color = colors[i, j];

                    tile.SetActive(true);
                    tiles[i, j] = setting;
                }
                else
                {
                    ViewTile setting = tiles[i, j];

                    setting.x = i;
                    setting.y = j;

                    setting.color = colors[i, j];

                    setting.Initialize();
                }
    }
}
