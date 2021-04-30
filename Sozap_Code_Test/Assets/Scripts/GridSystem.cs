using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public GameObject tilePrefab;
    public TileLevel[] themes;
    public int currentTheme;
    public Cell[,] Grid;
    public int level;

    // Start is called before the first frame update
    void Start()
    {

        SetUpGrid();
        
    }

    private void Update()
    {
        //level = Utils.currentlevel;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateTileTheme(currentTheme < themes.Length - 1 ? currentTheme += 1 : 0);
        }
    }

    public void SetUpGrid()
    {

       Utils.Vertical = (int)Camera.main.orthographicSize;
        Utils.Horizontal = Utils.Vertical * (Screen.width / Screen.height);
        Utils.Colums = Utils.Horizontal * 2;
        Utils.Rows = Utils.Vertical * 2;
        Grid = new Cell[Utils.Colums, Utils.Rows];

        for (int i = 0; i < Utils.Colums; i++)

            for (int j = 0; j < Utils.Rows; j++)

                Grid[i, j] = new Cell(tilePrefab, themes[currentTheme], i, j);

             
            
        
    }

    public void UpdateTileTheme(int index)
    {
        currentTheme = index;
        for (int i = 0; i < Utils.Colums; i++)
        {
            for (int j = 0; j < Utils.Rows; j++)
            {
                Grid[i, j].UpdateTileTheme(themes[currentTheme]);
            }
        }
    }



    public void NewLevel()
    {
        level++;
    }
    
}
