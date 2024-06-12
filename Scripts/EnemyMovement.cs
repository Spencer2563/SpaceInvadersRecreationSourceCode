using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    private int verticalBound = -45;
    private int horizontalBound = 85;
    private int moveDir = 1;
    private int yIncrement = 8;
    private float horizontalMoveSpeed = 10;


    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 yChange = new Vector3(0, -yIncrement, 0);
        float deltaTime = Time.deltaTime;
        if (moveDir == 1 && transform.position.x <= horizontalBound)
        {
            Vector3 moveDist = new Vector3(horizontalMoveSpeed * moveDir, 0, 0);
            transform.position += moveDist * deltaTime;
        }
        else if (moveDir == -1 && transform.position.x >= -horizontalBound)
        {
            Vector3 moveDist = new Vector3(horizontalMoveSpeed * moveDir, 0, 0);
            transform.position += moveDist * deltaTime;
        }
        else if (moveDir == 1 && transform.position.x >= horizontalBound)
        {
            transform.position += yChange;
            moveDir = -1;
        }
        else if (moveDir == -1 && transform.position.x <= -horizontalBound)
        {
            transform.position += yChange;
            moveDir = 1;
        }

    }
}
