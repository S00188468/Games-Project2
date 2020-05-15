using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool HasKey;
    public bool HasCrowbar;

    
    public void Start()
    {
        HasKey = false;
        HasCrowbar = false;
    }

    public bool CanClearDebri()
    {
        
        if (HasCrowbar==true)
        {
            return true;
        }
        return false;

    }
    public bool CanOpenDoor()
    {
        
        if (HasKey==true)
        {
            return true;
        }
        return false;
    }
    
    
}
