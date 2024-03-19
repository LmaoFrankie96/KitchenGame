using System;
using UnityEngine;
using UnityEngine.Events;

public class EventPublisher : MonoBehaviour
{
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    private int count;
    public event Action<OnSpacePressedEventArgs> ActionSpacePressed;
    public UnityEvent<OnSpacePressedEventArgs> OnSpacePressedUnity;
    public delegate void TestEventDelegate(float f);
    public TestEventDelegate TestEvent;
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
            ActionSpacePressed?.Invoke(new OnSpacePressedEventArgs { spaceCount = count });
            OnSpacePressedUnity?.Invoke(new OnSpacePressedEventArgs { spaceCount = count });
            TestEvent?.Invoke(5.5f);
        }
    }
}
