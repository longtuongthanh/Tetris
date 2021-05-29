using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool changed = false;
        GameData gameData = App.Instance.gameData;
        BoardViewer boardViewer = App.Instance.boardViewer;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            changed = true;
            
        }
    }
}
