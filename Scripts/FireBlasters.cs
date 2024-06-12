using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBlasters : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private GameObject bullet;
    [SerializeField] private ControllerState controllerState;
    private enum ControllerState
    {
        automated,
        controlled
    }
    public static int SharedEnemyBullet { get; set; }
    private void Start()
    {
        SharedEnemyBullet = 0;
        if (controllerState == ControllerState.controlled)
        {
            if (TryGetComponent<PlayerInput>(out PlayerInput playerInput))
            {
                playerInput.OnShoot += PlayerInput_OnShoot;
            }
            else { Debug.Log("No player input component found for fire event"); }
        }
        else if (controllerState == ControllerState.automated)
        {

        }
        else
        {
            Debug.LogError("No Controller State Given");
        }
        
    }

    private void Update()
    {
        if (controllerState == ControllerState.automated)
        {     // 1/50 chance to shoot basically just makes a dif alien shoot
            if (Mathf.RoundToInt(Random.Range(0, 50)) == 25)
            {
                if (bullet == null && SharedEnemyBullet < 1)
                { 
                bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    SharedEnemyBullet++;
                }
            }
        }
    }

    private void PlayerInput_OnShoot(object sender, System.EventArgs e)
    {
        if (bullet == null)
        {
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
         
    }



}
