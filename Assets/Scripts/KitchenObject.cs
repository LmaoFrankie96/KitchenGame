using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    private IKitchenObjectParent kitchenObjectParent;
    public KitchenObjectsSO GetKitchenObjectsSO() { return kitchenObjectsSO; }
    public void SetKitchenObjectParent(IKitchenObjectParent MkitchenObjectParent)
    {

        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = MkitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject()) {

            Debug.LogError("KitchenObjectParent already has a kitchen object!!!");
        }
        MkitchenObjectParent.SetKitchenObject(this);
        transform.parent = MkitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetClearCounter() { return this.kitchenObjectParent; }

}
