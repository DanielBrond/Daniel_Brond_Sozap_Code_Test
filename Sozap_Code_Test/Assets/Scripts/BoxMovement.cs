using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxMovement : MonoBehaviour
{
    
    private MapManager mapManager;
    private GridMovement playerObj;

    public DetectionBox boxDetection;


    private bool isMoving;
    private Vector3 ogPos, targetPos;
    private float timeToMove = 0.2f;

    public bool moveUp = true;
    public bool moveDown = true;
    public bool moveLeft = true;
    public bool moveRight = true;

    public BoxTileDetector[] tileDetector;
    private float distanceMargin;
    private float timeBeforeCheck;

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>(); 
        
    }


    void Update()
    {



    }


    public IEnumerator MovePlayer(Vector3 direction)
    {
        
        isMoving = true;

        float elapsedTime = 0;

        ogPos = transform.position;
        targetPos = ogPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(ogPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }





}
