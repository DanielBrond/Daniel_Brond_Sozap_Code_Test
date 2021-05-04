using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTileDetector : MonoBehaviour
{
    private MapManager mapManager;
    public BoxMovement BoxMovement;
    public DetectionBox detectionBox;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    private const float distanceMargin = 0.001f;
    public float timeBeforeCheck = 0.1f;
    private int counter;

    public BoxMovement box;
    public BoxTileDetector[] tileDetectors;

    public BoxTileDetector used_tileDector;


 
    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DetectionCheck());
    }

    // Update is called once per frame
    void Update()
    {
        DetectionDirection();
    }


    public void DetectionDirection()
    {
        if(up)
        {
            if(box == null)
            {
                BoxMovement.moveUp = mapManager.WallBlock(transform.position);
            }
            else
            {
                BoxMovement.moveUp = false;
            }
            
        }

        if (down)
        {
            if(box == null)
            {
                BoxMovement.moveDown = mapManager.WallBlock(transform.position);
            }
            else
            {
                BoxMovement.moveDown = false;
            }
            
        }
        if (left)
        {
            if(box == null)
            {
                BoxMovement.moveLeft = mapManager.WallBlock(transform.position);
            }
            else
            {
                BoxMovement.moveLeft = false;
            }
            
        }
        if (right)
        {
            if(box == null)
            {
                BoxMovement.moveRight = mapManager.WallBlock(transform.position);
            }
            else
            {
                BoxMovement.moveRight = false;
            }
            
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
                    Debug.Log("Works");
                    box = box3;
                    used_tileDector = this;
                }
                else
                {
                    counter++;
                    Debug.Log(counter);
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
