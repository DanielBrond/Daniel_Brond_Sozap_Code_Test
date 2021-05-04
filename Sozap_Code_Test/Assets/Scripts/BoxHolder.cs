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
        //StartCoroutine(DetectionCheck());
        stopCheck = true;
    }

    private void Update()
    {
       
            CheckForBox();
        
            
    }

    IEnumerator DetectionCheck()
    {

        while (true)
        {
            if (!occupied)
            {
                yield return new WaitForSeconds(timeBeforeCheck);


                foreach (var box3 in mapManager.boxes)
                {

                    if (Mathf.Abs(Vector3.Distance(transform.position, box3.transform.position)) < distanceMargin)
                    {
                        Debug.Log("Works");
                        box = box3;

                        occupied = true;

                        if (!occupied)
                        {
                            victoryCondition.AddBox();
                        }
                        
                    }
                    else
                    {
                        counter++;
                        //occupied = false;
                        Debug.Log(counter);

                    }
                }




                //if (counter == tileDetectors.Length * mapManager.boxes.Length)
                //{
                //    box = null;
                //    used_tileDector = null;
                //    occupied = false;
                //    victoryCondition.RemoveBox();

                //}

                counter = 0;
            }
        }
        

                
        
    }
        
    public void CheckForBox()
    {
      
        foreach (var box3 in mapManager.boxes)
        {

            if (Mathf.Abs(Vector3.Distance(transform.position, box3.transform.position)) < distanceMargin)
            {
                Debug.Log("Works");
                box = box3;

                
                if (!occupied)
                {
                    victoryCondition.AddBox();
                    occupied = true;
                    stopCheck = false;
                }
            }
            else
            {
                counter++;
                
                Debug.Log(counter);

            }
        }




        if (counter == holders.Length * mapManager.boxes.Length)
        {
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
