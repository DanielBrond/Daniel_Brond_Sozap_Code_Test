using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wall", menuName = "Tiles/Wall")]
public class TileWall : ScriptableObject
{
    public Sprite sprite;
    public float height;
}
