using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : PlayerInteractableObject
{
    public override void PlayerInteracted()
    {
        if (Inventory.CanClearDebri())
        {
            uiBehaviour.HidePlayerInteractMessage();
            Destroy(gameObject);
        }
    }
}
