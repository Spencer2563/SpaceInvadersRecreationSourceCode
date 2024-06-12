using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public int VerticalDirection {  get; private set; }
    public int HorizontalDirection { get; private set; }

    public event EventHandler OnShoot;


    void Update()
    {
        HorizontalDirection = 0;
        if (Input.GetKey(KeyCode.D))
        {
            HorizontalDirection = 1;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            HorizontalDirection = -1;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            OnShoot?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
