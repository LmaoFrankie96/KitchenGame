using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectsSO kitchenObject;
    [SerializeField] private Transform counterTopPoint;
    public void Interact() {

        Debug.Log("Interact!");
        Transform kitchenObjectTransform=Instantiate(kitchenObject.prefab, counterTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectsSO());
    }
}
