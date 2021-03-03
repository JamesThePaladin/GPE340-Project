using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponShotgun : WeaponGun
{
    [SerializeField, Tooltip("Amount of bullets fired with each trigger pull.")]
    protected float projectileCount; //the amount of projectiles to be fired
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void AttackStart()
    {
        base.AttackStart();
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }
    public override void ShootBullet()
    {
        //this for loop creates the amount of bullets specified by the projectile count.
        //it does this by looping through the ShootBullet function to instantiate the specified amount
        //it happens so fast that they appear to be made at the same time
        for (int i = 0; i < projectileCount; i++)
        {
            base.ShootBullet();
        }
    }
}
