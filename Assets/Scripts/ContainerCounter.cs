using System;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{

    public event EventHandler OnPlayerGrabObject;
    [SerializeField] private KitchenObjectsSO kitchenObjectSO;
    public override void Interact(Player player)
    {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabObject?.Invoke(this, EventArgs.Empty);
    }
  
}
