using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTileDetector : MonoBehaviour
{
    private MapManager mapManager;
    private GridMovement gridMovement;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private void Awake()
    {
    //    mapManager = FindObjectOfType<MapManager>();
    //    gridMovement = FindObjectOfType<GridMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DetectionDirection();
    }


    public void DetectionDirection()
    {
        if(up)
        {
            gridMovement.moveUp = mapManager.WallBlock(transform.position);
        }

        if (down)
        {
            gridMovement.moveDown = mapManager.WallBlock(transform.position);
        }
        if (left)
        {
            gridMovement.moveLeft = mapManager.WallBlock(transform.position);
        }
        if (right)
        {
            gridMovement.moveRight = mapManager.WallBlock(transform.position);
        }
    }
}
