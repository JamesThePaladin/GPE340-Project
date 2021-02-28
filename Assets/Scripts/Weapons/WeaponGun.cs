using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponGun : Weapon
{
    [Header("GameObjects")]
    public GameObject bulletPrefab;

    [Header("Firing Settings")]
    public float timeBetweenShots;
    protected float nextShootTime;
    public Transform firingPoint;
    

    // Start is called before the first frame update
    public override void Start()
    {
        //set the next time we can shoot to right now
        nextShootTime = Time.time;
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

    public void ShootBullet()
    {
        if (Time.time >= nextShootTime)
        {
            //Instantiate a bullet, have the bullet code do the rest
            GameObject playerBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            Bullet playerBulletScript = playerBullet.GetComponent<Bullet>();
            // TODO: Send all appropriate data to bullet
            playerBulletScript.damageDone = damage;
            //delay our next shot
            nextShootTime = Time.deltaTime + timeBetweenShots;
        }
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
