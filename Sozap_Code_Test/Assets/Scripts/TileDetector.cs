using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDetector : MonoBehaviour
{
    private MapManager mapManager;
    private GridMovement gridMovement;
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    private const float distanceMargin = 0.001f;
    public float timeBeforeCheck = 0.1f;

    
    public BoxMovement box;
    public TileDetector[] tileDetectors;

    public TileDetector used_tileDector;
    private int counter;

    public void OnEnable()
    {
        mapManager = FindObjectOfType<MapManager>();
       
    }
    private void Awake()
    {
      
        gridMovement = FindObjectOfType<GridMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetectionCheck());
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


    IEnumerator DetectionCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBeforeCheck);

           
                foreach (var box3 in mapManager.boxes)
                {

                    if (Mathf.Abs(Vector3.Distance(transform.position, box3.transform.position)) < distanceMargin)
                    {

                        box = box3;
                        used_tileDector = this;
                    }
                    else
                    {
                        counter++;
                        
                    }
                }


            

            if (counter == tileDetectors.Length * mapManager.boxes.Length)
            {
                box = null;
                used_tileDector = null;

            }

            counter = 0;
        }
    }
}
