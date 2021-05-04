using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHolder : MonoBehaviour
{
    private const float distanceMargin = 0.001f;
    public float timeBeforeCheck = 0.1f;
  
    public TileDetector[] tileDetectors;
    public BoxHolder[] holders;
    public BoxMovement box;
    private int counter;

    private bool stopCheck;

    public bool occupied;

    VictoryCondition victoryCondition;
    MapManager mapManager;

    public TileDetector used_tileDector;
    // Start is called before the first frame update

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        victoryCondition = FindObjectOfType<VictoryCondition>();

    }
    void Start()
    {
        stopCheck = true;
    }

    private void Update()
    {
       
            CheckForBox();

    }

   
        
    public void CheckForBox()
    {
      
        foreach (var box3 in mapManager.boxes)
        {

            if (Mathf.Abs(Vector3.Distance(transform.position, box3.transform.position)) < distanceMargin)
            {
                box = box3;

                
                if (!occupied)
                {
                    victoryCondition.AddBox();
                    box.GetComponent<SpriteRenderer>().color = Color.green;
                    occupied = true;
                    stopCheck = false;
                }
            }
            else
            {
                counter++;
            }
        }




        if (counter == holders.Length * mapManager.boxes.Length)
        {
            if(box != null)
            {
                box.GetComponent<SpriteRenderer>().color = Color.white;
            }
            
            box = null;
            used_tileDector = null;
            

            if (!stopCheck)
            {
                victoryCondition.RemoveBox();
                stopCheck = true;
                occupied = false;
            }
            

        }

        counter = 0;

    }

}
