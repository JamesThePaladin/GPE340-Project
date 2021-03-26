using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpCorePickup : Pickup
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnPickUp(HumanoidPawn entity)
    {
        GameManager.instance.Win();
        base.OnPickUp(entity);
    }
}
