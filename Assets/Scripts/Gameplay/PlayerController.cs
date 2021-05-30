using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TetrisController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool changed = false;
        GameData gameData = app.gameData;
        BoardViewer boardViewer = app.boardViewer;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changed = true;
            Move(gameData, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            changed = true;
            Move(gameData, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            changed = true;
            Move(gameData, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changed = true;
            RotateWithKick(gameData, true);
        }
        if (changed)
            app.NotifyBoardChanged();
    }
}
