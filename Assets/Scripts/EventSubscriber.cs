using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    private EventPublisher publisher;

    private void Start()
    {
        publisher = GetComponent<EventPublisher>();
        publisher.OnSpacePressed += Test_OnSpacePressed;
    }

    private void Test_OnSpacePressed(object sender, System.EventArgs e)
    {
        Debug.Log("Space bar pressed");
    }

}
