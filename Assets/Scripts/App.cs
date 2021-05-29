using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static App Instance { get => inst; }
    private static App inst;

    App()
    {
        inst = this;
    }

    public GameData gameData;
    public PlayerController playerController;
    public BoardViewer boardViewer;
}
