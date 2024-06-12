using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject highValuePrefab;
    [SerializeField] private GameObject midValuePrefab;
    [SerializeField] private GameObject lowValuePrefab;
    public static int TotalEnemyShips { get; set; }

    private void Start()
    {
        TotalEnemyShips = 0;
    }
    void Update()
    {
        if (TotalEnemyShips == 0)
        {
            float initialX = -40;
            float initialY = 40;
            float xIncriment = 8;
            float yIncrement = -8;
            Vector3 spawnTransform = new Vector3(initialX, initialY, -2);
            // high value ships
            for (int i= 0; i < 10; i++)
            {
                if (i>0) { spawnTransform.x += xIncriment; }
                Instantiate(highValuePrefab, spawnTransform, Quaternion.identity, transform);
                TotalEnemyShips++;
            }
            // mid value ships
            spawnTransform.y += yIncrement;
            spawnTransform.x = initialX;
            for (int i= 0;i < 10;i++)
            {
                if (i>0) { spawnTransform.x += xIncriment; }
                Instantiate(midValuePrefab, spawnTransform, Quaternion.identity, transform);
                TotalEnemyShips++;
            }
            spawnTransform.y += yIncrement;
            spawnTransform.x = initialX;
            for (int i = 0; i < 10; i++)
            {
                if (i > 0) { spawnTransform.x += xIncriment; }
                Instantiate(midValuePrefab, spawnTransform, Quaternion.identity, transform);
                TotalEnemyShips++;
            }
            spawnTransform.y += yIncrement;
            spawnTransform.x = initialX;
            for (int i = 0; i < 10; i++)
            {
                if (i > 0) { spawnTransform.x += xIncriment; }
                Instantiate(lowValuePrefab, spawnTransform, Quaternion.identity, transform);
                TotalEnemyShips++;
            }
            spawnTransform.y += yIncrement;
            spawnTransform.x = initialX;
            for (int i = 0; i < 10; i++)
            {
                if (i > 0) { spawnTransform.x += xIncriment; }
                Instantiate(lowValuePrefab, spawnTransform, Quaternion.identity, transform);
                TotalEnemyShips++;
            }
        }

    }
}
