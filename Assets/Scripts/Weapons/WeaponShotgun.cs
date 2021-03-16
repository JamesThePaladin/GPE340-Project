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
            //Instantiate a bullet, have the bullet code do the rest
            GameObject playerBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation * Quaternion.Euler(Random.onUnitSphere * spread));
            //get the bullet component from the newly created bullet
            Bullet playerBulletScript = playerBullet.GetComponent<Bullet>();
            //set the owner of the bullet to this compnent's owner
            playerBulletScript.owner = owner;
            //set it's layer to our owners layer so we don't hit ourselves
            playerBullet.gameObject.layer = owner.gameObject.layer;
            //set the bullet's damage equal to our waepon's damage
            playerBulletScript.damageDone = damage;
            //delay our next shot
            nextShootTime = Time.time + timeBetweenShots;
        }
        //increment the amount of shots fired
        shotsFired++;
        //decrement the ammo count
        currentAmmo--;
    }
}
