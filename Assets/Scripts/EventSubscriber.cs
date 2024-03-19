using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private EventPublisher publisher;

    private void Start()
    {
        publisher = GetComponent<EventPublisher>();
        publisher.OnSpacePressed += Test_OnSpacePressed;
    }

    private void Test_OnSpacePressed(object sender, EventPublisher.OnSpacePressedEventArgs e)
    {
        Debug.Log("Space bar pressed" + e.spaceCount);
        //publisher.OnSpacePressed -= Test_OnSpacePressed;
    }

}
