using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    private ClearCounter clearCounter;
    public KitchenObjectsSO GetKitchenObjectsSO() { return kitchenObjectsSO; }
    public void SetClearCounter(ClearCounter mClearCounter)
    {

        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = mClearCounter;

        if (clearCounter.HasKitchenObject()) {

            Debug.LogError("Counter already has a kitchen object!!!");
        }
        mClearCounter.SetKitchenObject(this);
        transform.parent = mClearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter() { return this.clearCounter; }

}
