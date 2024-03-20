using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    private ClearCounter clearCounter;
    public KitchenObjectsSO GetKitchenObjectsSO() { return kitchenObjectsSO; }
    public void SetClearCounter(ClearCounter mClearCounter) { 
    
        this.clearCounter = mClearCounter;
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter() { return this.clearCounter; } 

}
