using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;


    [SerializeField]
    private TileBase occupiedTile;
    private TileBase grassTile;

    [SerializeField]
    private MapManager mapManager;
    private List<Vector3Int> activeTile = new List<Vector3Int>();
    private List<TileData> tileDatas;


    private Dictionary<TileBase, TileData> dataFromTiles;

    public void notOccupied(Vector3Int position)
    {
        map.SetTile(position, occupiedTile);
        
    }

    //public void TryOccupyTile(Vector3Int tilePosition)
    //{
             
        
    //    //TileData data = mapManager.GetTileData(tilePosition);

    //    if(data != null && data.wall)
    //    {
    //        this.OccupyTile(tilePosition, data);
    //        //this.data.wall = false;
    //        Debug.Log("Works");
    //       TileBase tile = map.GetTile(tilePosition);
            
          
    //    }

    //}

    public void OccupyTile(Vector3Int tilePos, TileData data)
    {
        
        data.wall = false;
    }



}
