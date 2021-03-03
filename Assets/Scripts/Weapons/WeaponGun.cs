using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponGun : Weapon
{
    [Header("GameObjects")]
    public GameObject bulletPrefab;

    [Header("Firing Settings")]
    [SerializeField, Tooltip("The interval of shots fired between tracer shots")]
    protected int tracerShotInterval = 5;
    protected int shotsFired = 0;
    protected int nextTracerShot;
    public float timeBetweenShots = 1f;
    protected float nextShootTime;
    public Transform firingPoint;
    [SerializeField,Range(0, 20),Tooltip("This controls the bullet spread of the gun.")]
    protected float spread = 0;

    protected override void Awake()
    {
        //set the next time we can shoot to right now
        nextShootTime = Time.time;
        base.Awake();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        //set the next time we fire a tracer shot
        nextTracerShot = shotsFired + tracerShotInterval;
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        CanShoot();
        base.FixedUpdate();
    }

    public override void AttackStart()
    {
        if (CanShoot())
        {
            base.AttackStart(); 
        }
    }

    public override void AttackEnd()
    {
        base.AttackEnd();
    }

    public virtual void ShootBullet()
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
            //increment the amount of shots fired
            shotsFired++;
            //delay our next shot
            nextShootTime = Time.time + timeBetweenShots;
        
    }

    public bool CanShoot() 
    {
        if (Time.time >= nextShootTime)
        {
            nextShootTime = Time.time;
            return true;
        }
        else { return false; }
    }

    public void MuzzleFlash()
    {
        // TODO: Instantiate muzzle flash
    }

    public void CheckAndDoTracer()
    {
        
            if (shotsFired >= nextTracerShot)
            {
                Debug.Log("I'm shooting a tracer!");
                //Instantiate a bullet, have the bullet code do the rest
                GameObject playerBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation * Quaternion.Euler(Random.onUnitSphere * spread));
                playerBullet.gameObject.layer = gameObject.layer;
                //set the trailrenderer on the bullet to active
                TrailRenderer tracer = playerBullet.GetComponent<TrailRenderer>();
                //set it to active
                tracer.enabled = true;
                Bullet playerBulletScript = playerBullet.GetComponent<Bullet>();
                playerBulletScript.owner = owner;
                // TODO: Send all appropriate data to bullet
                playerBulletScript.damageDone = damage;
                //increment the next tracer shot round firing time
                nextTracerShot = shotsFired + tracerShotInterval;
                //delay our next shot
                nextShootTime = Time.deltaTime + timeBetweenShots;
            } 
        
    }

    public void CheckForJam()
    {
        // TODO: Check if the jam chance roll failed -- if so, jam gun
    }
}
