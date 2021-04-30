using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Tile Theme", menuName ="Tiles/Themes")]
public class TileLevel : ScriptableObject
{
    public Sprite[] tiles;
    public TileWall[] wall;
}
