using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;


    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public bool WallBlock(Vector2 worldPosition)
    {
        Vector3Int gridPos = map.WorldToCell(worldPosition);

        TileBase tile = map.GetTile(gridPos);
        if (tile == null)
        {
            return false;
        }


        bool blocked = dataFromTiles[tile].wall;
        return blocked;

        
    }

    public bool goal(Vector2 worldPosition)
    {
        Vector3Int gridPos = map.WorldToCell(worldPosition);

        TileBase tile = map.GetTile(gridPos);
        if (tile == null)
        {
            return false;
        }


        bool blocked = dataFromTiles[tile].goal;
        return blocked;

        
    }

   


}
