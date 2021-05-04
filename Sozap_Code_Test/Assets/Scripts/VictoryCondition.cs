using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    public int currentLevel;

    public int boxHolders;
    public int occupied;

    private BoxMovement[] boxes;
    private ManagerGame gameManager;

    private void OnEnable()
    {
        boxes = FindObjectsOfType<BoxMovement>();
        boxHolders = boxes.Length;
        gameManager = FindObjectOfType<ManagerGame>();
    }

    public void CheckForVictory()
    {
        if (currentLevel == 1)
        {
            if(boxHolders == occupied)
            {
                gameManager.LevelCompleted();
            }
        }

        if (currentLevel == 2)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
            }
        }

        if (currentLevel == 3)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
            }
        }
        if (currentLevel == 4)
        {
            if (boxHolders == occupied)
            {
                gameManager.LevelCompleted();
            }
        }
    }

    public void AddBox()
    {
        occupied++;
        CheckForVictory();
    }

    public void RemoveBox()
    {
        occupied--;
        CheckForVictory();
    }
}
