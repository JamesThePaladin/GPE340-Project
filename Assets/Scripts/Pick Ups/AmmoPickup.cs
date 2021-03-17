using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{
    [SerializeField, Range(0, 100),Tooltip("The ammount of ammo to be added on pickup.")]
    private int addedAmmo = 50;
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
        if (!entity.weapon)
        {
            //do nothing
        }
        else if (entity.weapon.currentAmmo < entity.weapon.maxAmmo)
        {
            entity.weapon.currentAmmo = AddAmmo(entity, entity.weapon.currentAmmo);
            base.OnPickUp(entity);
        }
    }

    public int AddAmmo(Pawn entity, int currentAmmo) 
    {
        addedAmmo = Mathf.Max(addedAmmo, 0);
        currentAmmo = Mathf.Clamp(currentAmmo + addedAmmo, 0, entity.weapon.maxAmmo);
        return currentAmmo;
    }
}
