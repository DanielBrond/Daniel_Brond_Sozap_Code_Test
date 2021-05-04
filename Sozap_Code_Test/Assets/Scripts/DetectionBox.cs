using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBox : MonoBehaviour
{
    private const float distanceMargin = 0.001f;
    public float timeBeforeCheck = 0.1f;
    public BoxMovement boxMovement;
    public BoxTileDetector[] tileDetectors;
    public GridMovement gridMovement;
    private int counter;

    public BoxMovement box;
    public GridMovement tempPlayer;

    MapManager mapManager;

    public BoxTileDetector used_tileDector;
    public BoxTileDetector used_tileDectorBox;
    public BoxMovement tempBoxDown;
    public BoxMovement tempBoxUp;
    public BoxMovement tempBoxLeft;
    public BoxMovement tempBoxRight;

    // Start is called before the first frame update

    private void Awake()
    {
        gridMovement = FindObjectOfType<GridMovement>();
        mapManager = FindObjectOfType<MapManager>();

    }
    void Start()
    {
        
        
    }

    private void Update()
    {
        CheckDetectionTiles();
    }



    public void CheckDetectionTiles()
    {
        foreach (var item in tileDetectors)
        {
            if (item.name == "Backward")
            {
                if (item.box != null)
                {
                    tempBoxDown = item.box;
                }
                else if (item.box == null)
                {
                    tempBoxDown = null;
                }
            }
            if (item.name == "Forward")
            {
                if (item.box != null)
                {
                    tempBoxUp = item.box;
                }
                else if (item.box == null)
                {
                    tempBoxUp = null;
                }
            }
            if (item.name == "Left")
            {
                if (item.box != null)
                {

                    tempBoxLeft = item.box;
                }
                else if (item.box == null)
                {
                    tempBoxLeft = null;
                }
            }
            if (item.name == "Right")
            {
                if (item.box != null)
                {
                    tempBoxRight = item.box;
                }
                else if (item.box == null)
                {
                    tempBoxRight = null;
                }
            }
        }




    }


}
