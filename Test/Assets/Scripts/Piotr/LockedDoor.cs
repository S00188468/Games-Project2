using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : PlayerInteractableObject
{
    
    public override void PlayerInteracted()
    {
        if (Inventory.CanOpenDoor())
        {
            uiBehaviour.HidePlayerInteractMessage();
            Destroy(gameObject);
        }
    }
}
