using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTile : TetrisBehaviour
{
    public int x;
    public int y;
    public float baseX = 50;
    public float baseY = 300;
    public float size = 50;
    public Color? color;

    public void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (baseX == 0)
            baseX = (transform as RectTransform).anchoredPosition.x;

        if (baseY == 0)
            baseY = (transform as RectTransform).anchoredPosition.y;

        if (size == 0)
            size = (transform as RectTransform).sizeDelta.x;

        float posX = x * size + baseX;
        float posY = y * size + baseY;
        (transform as RectTransform).anchoredPosition = new Vector2(posX, posY);

        if (color != null)
            GetComponent<Image>().color = color.Value;
        else
            GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
    }
}
