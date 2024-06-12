using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 55;
    [SerializeField] private float verticalBound = 45;
    [SerializeField] private float horizontalBound = 85;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    { 

        
        float deltaTime = Time.deltaTime;
        if (TryGetComponent<PlayerInput>(out PlayerInput playerInput))
        {

            Vector3 moveDir = new Vector3(playerInput.HorizontalDirection, 0, 0);
            
            if (moveDir.x < 0 && !(transform.position.x > -horizontalBound))
            {
                // check while ship is moving left
                moveDir.x = 0;
            }
            if (moveDir.x > 0 && !(transform.position.x < horizontalBound))
            {
                // check while ship is moving right
                moveDir.x = 0;
            }
            
            Vector3 moveDistance = new Vector3(moveDir.x, moveDir.y, 0).normalized * deltaTime * moveSpeed;
            transform.position += moveDistance;
        }
        
    }
}
