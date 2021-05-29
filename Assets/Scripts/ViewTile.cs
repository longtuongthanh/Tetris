using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTile : MonoBehaviour
{
    public int x;
    public int y;
    public int baseX = 50;
    public int baseY = 300;
    public int size = 50;
    public Color color;

    public void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        int posX = x * size + baseX;
        int posY = y * size + baseY;
        (transform as RectTransform).anchoredPosition = new Vector2(posX, posY);

        if (color != null)
            GetComponent<Image>().color = color;
    }
}
