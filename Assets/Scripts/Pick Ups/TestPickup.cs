using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPickup : Pickup
{
    protected override void OnPickUp(HumanoidPawn entity) 
    {
        Debug.Log("I've been picked up by, ", entity);
        base.OnPickUp(entity);
    }
}
