using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {

            //has no kitchen object on it
            if (player.HasKitchenObject())
            {
                //Player carrying kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player carrying nothing
            }
        }
        else
        {
            //has kitchen object on it
            if (player.HasKitchenObject())
            {
                //Player carrying kitchen object

            }
            else
            {
                //Player carrying nothing
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }
}
