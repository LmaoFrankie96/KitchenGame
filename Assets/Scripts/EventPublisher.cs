using System;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    private int count;

    private void Awake()
    {
        count = 0;
    }
    public class OnSpacePressedEventArgs : EventArgs
    {

        public int spaceCount;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = count });
        }
    }
}
