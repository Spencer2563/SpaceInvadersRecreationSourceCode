using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 55f;
    [SerializeField] float maxMoveDistance = 85f;
    [SerializeField] public moveDirection direction;
    public enum moveDirection
    {
        forward =1,
        backward =-1
    }

    private Vector3 initialLocation;

    private void Start()
    {
        initialLocation = transform.position;
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        Vector3 moveDistance = new Vector3(0, moveSpeed, 0);
        transform.position += moveDistance * deltaTime * (float)direction;

        if (Mathf.Abs(transform.position.y - initialLocation.y) >= maxMoveDistance)
        {
            
            if(transform.gameObject != null)
            {
                Destroy(transform.gameObject);
                if (direction == moveDirection.backward)
                {
                    FireBlasters.SharedEnemyBullet = 0;
                }
                
            }
            
        }
            
        
    }
    
    
}
