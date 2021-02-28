using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Pickup
{
    [SerializeField, Range(0, 100), Tooltip("The value to increase weapon damage by when this is picked up")]
    private float damageBuff;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Update();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnPickUp(HumanoidPawn entity)
    {
        float weaponDamage = entity.GetComponent<Weapon>().damage;
        weaponDamage += damageBuff; 
        base.OnPickUp(entity);
    }
}
