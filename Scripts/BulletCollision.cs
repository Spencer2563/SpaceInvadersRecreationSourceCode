using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private Layers targetLayer;
    [SerializeField] private float rayDist = 2f;
    enum Layers
    {
        enemy = 3,
        player = 7
    }

    private void Start()
    {
    }

    private void Update()
    {
        RaycastHit2D result = Physics2D.Raycast(transform.position, transform.up, rayDist, 1<<(int)targetLayer);
        if (result != null  && result.transform != null && result.transform.gameObject != null)
        {
            Debug.Log("hitting " + transform.gameObject + " on layer " + targetLayer);
            Destroy(result.transform.gameObject);

            BulletMove bulletMover = this.GetComponent<BulletMove>();
            // checks the bullet for enemy signature
            if (bulletMover.direction == BulletMove.moveDirection.backward)
            {
                FireBlasters.SharedEnemyBullet = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                ShipSpawner.TotalEnemyShips -= 1;
            }
                Destroy(transform.gameObject);

        }
    }
}
