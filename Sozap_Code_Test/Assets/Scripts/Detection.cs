using System.Collections;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private const float distanceMargin = 0.001f;
    public float timeBeforeCheck = 0.1f;
    public GridMovement gridMovement;
    public TileDetector[] tileDetectors;


    public BoxMovement tempBoxDown;
    public BoxMovement tempBoxUp;
    public BoxMovement tempBoxLeft;
    public BoxMovement tempBoxRight;

    public BoxMovement box;
    private int counter;

     

    MapManager mapManager;

    public TileDetector used_tileDector;
    // Start is called before the first frame update

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        
    }

    private void Update()
    {
        
        CheckDetectionTiles();
    }


    public void CheckDetectionTiles()
    {
        foreach (var item in tileDetectors)
        {
            if(item.name == "Backward")
            {
                if(item.box != null)
                {
                    
                    tempBoxDown = item.box;
                }
                else if(item.box == null)
                {
                    tempBoxDown = null;
                }
            }
            if(item.name == "Forward")
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
