using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponRifle : Weapon
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void AttackStart()
    {
        base.AttackStart();
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }

    public void ShootBullet() 
    {
        // Instantiate a bullet, have the bullet code do the rest
    }

    public void MuzzleFlash() 
    {
        // TODO: Instantiate muzzle flash
    }

    public void CheckAndDoTracer() 
    {
        // TODO: Check if this is every 5th shot, if so, fire tracer instead of normal bullet
    }

    public void CheckForJam() 
    {
        // TODO: Check if the jam chance roll failed -- if so, jam gun
    }
}
