using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartMVCVersion()
    {
        SceneManager.LoadScene("TetrisMVC");
    }

    public void StartNormalVersion()
    {
        SceneManager.LoadScene("TetrisNormal");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
