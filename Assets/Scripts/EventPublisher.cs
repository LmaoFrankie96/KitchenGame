using System;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    public event EventHandler OnSpacePressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
        
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
        }
    }
}
