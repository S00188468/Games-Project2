using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PlayerInteractableObject
{
    public override void PlayerInteracted()
    {
        uiBehaviour.HidePlayerInteractMessage();
        Destroy(gameObject);
    }

}
