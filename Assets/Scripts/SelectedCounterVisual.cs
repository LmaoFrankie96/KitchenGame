using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject selectedCounterVisual;
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.counterSelected == clearCounter)
        {
            Show(selectedCounterVisual);
        }
        else { 
        
            Hide(selectedCounterVisual);
        }
    }

    private void Show(GameObject visual) { 
        visual.SetActive(true);
    }
    private void Hide(GameObject visual)
    {
        visual.SetActive(false);
    }
}
