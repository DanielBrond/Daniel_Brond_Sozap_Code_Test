using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public AudioSource audioSource;
    private MapManager mapManager;
    private bool isMoving;
    private Vector3 moveDir;
    public bool moveUp = true;
    public bool moveDown = true;
    public bool moveLeft = true;
    public bool moveRight = true;

    public bool isBlocked;
    private Vector3 ogPos, targetPos;
    private float timeToMove = 0.2f;

    public BoxMovement box;
    public Detection detection;

    public TileDetector[] tileDetector;
    

    private void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        tileDetector = FindObjectsOfType<TileDetector>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving && moveUp)
        {
            if (detection.tempBoxUp == null)
            {
                moveDir = Vector3.up;
                StartCoroutine(MovePlayer(moveDir));
            }
            else
            {
                if (!detection.tempBoxUp.moveUp)
                {
                    return;
                }
                else
                {
                    moveDir = Vector3.up;
                    StartCoroutine(MovePlayer(moveDir));
                }
            }

        }
            
        if (Input.GetKey(KeyCode.A) && !isMoving && moveLeft)
        {
            if (detection.tempBoxLeft == null)
            {
                moveDir = Vector3.left;
                StartCoroutine(MovePlayer(moveDir));
            }
            else
            {
                if (!detection.tempBoxLeft.moveLeft)
                {
                    return;
                }
                else
                {
                    moveDir = Vector3.left;
                    StartCoroutine(MovePlayer(moveDir));
                }
            }
        }
            
        if (Input.GetKey(KeyCode.S) && !isMoving && moveDown)
        {
            if(detection.tempBoxDown == null)
            {
                moveDir = Vector3.down;
                StartCoroutine(MovePlayer(moveDir));
            }
            else
            {
                if (!detection.tempBoxDown.moveDown)
                {
                    return;
                }
                else
                {
                    moveDir = Vector3.down;
                    StartCoroutine(MovePlayer(moveDir));
                }
            }
            
        }
            
        if (Input.GetKey(KeyCode.D) && !isMoving && moveRight)
        {
            if (detection.tempBoxRight == null)
            {
                moveDir = Vector3.right;
                StartCoroutine(MovePlayer(moveDir));
            }
            else
            {
                if (!detection.tempBoxRight.moveRight)
                {
                    return;
                }
                else
                {
                    moveDir = Vector3.right;
                    StartCoroutine(MovePlayer(moveDir));
                }
            }
        }
            


    }

 


    public IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        ogPos = transform.position;
        targetPos = ogPos + direction;

        CheckToMoveBox();
        audioSource.Play();
        while (elapsedTime < timeToMove)
        {
            
            transform.position = Vector3.Lerp(ogPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        foreach(var tile in tileDetector)
        {
            tile.DetectionDirection();
        }
        transform.position = targetPos;
        
        isMoving = false;
    }


    public void CheckToMoveBox()
    {
        if (detection.tempBoxUp != null)
        {

            if (moveDir == Vector3.up && detection.tempBoxUp.moveUp)
            {
                StartCoroutine(detection.tempBoxUp.MovePlayer(new Vector3(0.0f, 1.0f, 0.0f)));
            }
        }

        if(detection.tempBoxDown != null)
        {
            if (moveDir == Vector3.down && detection.tempBoxDown.moveDown)
            {
                StartCoroutine(detection.tempBoxDown.MovePlayer(new Vector3(0.0f, -1.0f, 0.0f)));
            }
        }

        if (detection.tempBoxLeft != null)
        {
            if (moveDir == Vector3.left && detection.tempBoxLeft.moveLeft)
            {
                StartCoroutine(detection.tempBoxLeft.MovePlayer(new Vector3(-1.0f, 0.0f, 0.0f)));
            }
        }


        if (detection.tempBoxRight != null)
        {
            if (moveDir == Vector3.right && detection.tempBoxRight.moveRight)
            {
                StartCoroutine(detection.tempBoxRight.MovePlayer(new Vector3(1.0f, 0.0f, 0.0f)));
            }
        }


        
    }
}
