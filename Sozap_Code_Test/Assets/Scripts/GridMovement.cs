using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private MapManager mapManager;
    private bool isMoving;

    public bool moveUp = true;
    public bool moveDown = true;
    public bool moveLeft = true;
    public bool moveRight = true;

    public bool isBlocked;
    private Vector3 ogPos, targetPos;
    private float timeToMove = 0.2f;

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving && moveUp)
            StartCoroutine(MovePlayer(Vector3.up));
        if (Input.GetKey(KeyCode.A) && !isMoving && moveLeft)
            StartCoroutine(MovePlayer(Vector3.left));
        if (Input.GetKey(KeyCode.S) && !isMoving && moveDown)
            StartCoroutine(MovePlayer(Vector3.down));
        if (Input.GetKey(KeyCode.D) && !isMoving && moveRight)
            StartCoroutine(MovePlayer(Vector3.right));

      
    }


    private IEnumerator MovePlayer(Vector3 direction)
    {
        
            isMoving = true;

            float elapsedTime = 0;

            ogPos = transform.position;
            targetPos = ogPos + direction;

            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(ogPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.position = targetPos;

            isMoving = false;

     


    }
}
