using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : TetrisBehaviour
{
    public Button LeftButton;
    public Button RightButton;
    public Button LeftRotateButton;
    public Button RightRotateButton;
    public Button DownButton;

    // Start is called before the first frame update
    void Start()
    {
        LeftButton.onClick.AddListener(app.playerController.MoveLeft);
        RightButton.onClick.AddListener(app.playerController.MoveRight);
        //LeftRotateButton.onClick.AddListener(app.playerController.RotateLeft);
        RightRotateButton.onClick.AddListener(app.playerController.RotateRight);
        DownButton.onClick.AddListener(app.playerController.MoveDown);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
