using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] selectedCounterVisual;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.counterSelected == baseCounter)
        {
            Show(selectedCounterVisual);
        }
        else
        {

            Hide(selectedCounterVisual);
        }
    }

    private void Show(GameObject[] visual)
    {
        foreach (GameObject visualGameObject in visual)
        {

            visualGameObject.SetActive(true);
        }
    }
    private void Hide(GameObject[] visual)
    {
        foreach (GameObject visualGameObject in visual)
        {

            visualGameObject.SetActive(false);
        }
    }
}
