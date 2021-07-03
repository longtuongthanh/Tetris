using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{
    public Vector3 rotationPoint;
    public static int height = 20;
    public static int width = 10;
    private float previousTime;
    private static Transform[,] grid = new Transform[width, height];

    public void Rotate()
    {
        transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
        if (!IsValidMove())
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
        }
    }
    public static void ClearGrid()
    {
        foreach(var cell in grid)
        {
            Destroy(cell.gameObject);
        }
        grid = new Transform[width, height];
    }
    public void MoveToEnd()
    {
        while (MoveDown())
        {

        }
    }
    public bool IsLose()
    {
        for (int x = 0; x < width; x++)
        {
        }
        return false;
    }
    
    public bool MoveDown()
    {
        transform.position += new Vector3(0, -1, 0);
        if (!IsValidMove())
        {
            transform.position += new Vector3(0, 1, 0);
            this.enabled = false;
            NormalTetrisController.Instance.AddBlockScore();
            AddToGrid();
            CheckLines();
            FindObjectOfType<Spawner>().SpawnNewBlock();
            return false;
        }

        SoundManager.Ins.Play(AudioClipEnum.Click);

        return true;

    }
    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!IsValidMove())
        {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!IsValidMove())
        {
            transform.position -= new Vector3(1, 0, 0);
        }
    }

    private bool IsValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null) return false;
        }
        return true;
    }

    private void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    private void CheckLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                NormalTetrisController.Instance.AddLineScore();
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    private bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null) return false;
        }
        return true;
    }

    private void DeleteLine(int i)
    {
        Instantiate(NormalTetrisController.Instance.LineFxAnimator.gameObject, new Vector3(4,i,-3), Quaternion.identity);
        
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j,i].gameObject);
            grid[j,i] = null;
        }

        SoundManager.Ins.Play(AudioClipEnum.Congrat);
    }

    private void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j =  0;  j < width; j++)
            {
                if (grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

}
