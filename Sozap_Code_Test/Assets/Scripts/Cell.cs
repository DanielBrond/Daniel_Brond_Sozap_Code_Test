using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Cell
{
    readonly GameObject Prefab;
    public GameObject gameObject;
    public SpriteRenderer renderer;
    public int X;
    public int Y;
    public TileLevel Wall;
    public CellWall wallDec;
    public Cell(GameObject prefab, TileLevel wall, int x, int y)
    {
        Prefab = prefab;
        X = x;
        Y = y;
        gameObject = GameObject.Instantiate(prefab, Utils.GridToWorldPosition(x, y), Quaternion.identity);
        renderer = gameObject.GetComponent<SpriteRenderer>();
        gameObject.name = "X:" + x + "Y: " + y;
        Wall = wall;
        renderer.sprite = wall.tiles[Utils.GetTile(X, Y)];
        wallDec = new CellWall();
        if (!Utils.IsEdgeTile(x, y))
        {
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                AddWalls();
        }
    }

    public void UpdateTileTheme(TileLevel wall, float fillRate = 1f)
    {
        Wall = wall;
        renderer.sprite = wall.tiles[Utils.GetTile(X, Y)];
        
    }

    public void AddWalls()
    {
        if(!wallDec.isCreated)
            wallDec = new CellWall(Prefab, Wall.wall[Random.Range(0, Wall.wall.Length)], X, Y, gameObject.transform);
    }
    public void ClearWall()
    {
        GameObject.Destroy(wallDec.gameObject);
        wallDec = new CellWall();
    }
}


public struct CellWall
{
    public bool isCreated;
    public GameObject gameObject;
    public SpriteRenderer renderer;
    public CellWall(GameObject prefab, TileWall wall, int x, int y, Transform parent = null)
    {
        gameObject = GameObject.Instantiate(prefab, Utils.GridToWorldPosition(x, y), Quaternion.identity, parent);
        gameObject.name = "X:" + x + "Y: " + y;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = wall.sprite;
        isCreated = true;
    }
    public void UpdateTile(TileLevel wall)
    {
        if (renderer)
            renderer.sprite = wall.wall[1].sprite;
    }
}
