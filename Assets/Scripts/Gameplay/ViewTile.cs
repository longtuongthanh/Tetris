using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTile : TetrisBehaviour
{
    public int x;
    public int y;
    public int baseX = 50;
    public int baseY = 300;
    public int size = 50;
    public Color? color;

    public void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (baseX == 0)
            baseX = (int)(transform as RectTransform).anchoredPosition.x;

        if (baseY == 0)
            baseY = (int)(transform as RectTransform).anchoredPosition.y;

        if (size == 0)
            size = (int)(transform as RectTransform).sizeDelta.x;

        int posX = x * size + baseX;
        int posY = y * size + baseY;
        (transform as RectTransform).anchoredPosition = new Vector2(posX, posY);

        if (color != null)
            GetComponent<Image>().color = color.Value;
        else
            GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
    }
}
