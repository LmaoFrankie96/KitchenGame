using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private EventPublisher publisher;

    private void Start()
    {
        publisher = GetComponent<EventPublisher>();
        publisher.OnSpacePressed += Test_OnSpacePressed;
        publisher.ActionSpacePressed += Test_ActionSpacePressed;
        publisher.TestEvent += Test_OnTestEvent;
    }

    private void Test_ActionSpacePressed(EventPublisher.OnSpacePressedEventArgs obj)
    {
        Debug.Log("Space bar pressed Action Delegate" + obj.spaceCount);
    }

    private void Test_OnSpacePressed(object sender, EventPublisher.OnSpacePressedEventArgs e)
    {
        Debug.Log("Space bar pressed" + e.spaceCount);
        //publisher.OnSpacePressed -= Test_OnSpacePressed;
    }

    public void Test_OnSpacePressedUnityEvent(EventPublisher.OnSpacePressedEventArgs e) {

        Debug.Log("Space bar pressed through Unity event"+e.spaceCount);
    }
    public void Test_OnTestEvent(float f) {

        Debug.Log("Space bar pressed through custom delegate event" + f);
    }
}
