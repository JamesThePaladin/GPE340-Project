using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunPickup : Pickup
{
    [SerializeField]
    private GameObject shotGunPrefab;
    public override void Awake()
    {
        base.Awake();
    }
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
        if (entity.weapon == null)
        {
            //find the appropriate spawn point on the entity
            GameObject parentObject = GameObject.Find("TwoHandedGunSpawnPoint");
            //get the transform
            Transform weaponSpawn = parentObject.GetComponent<Transform>();
            //name it weapon and spawn it at that points position, rotation, and as a child of it
            GameObject Weapon = Instantiate(shotGunPrefab, weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
            //get the weapon component of Weapon Object
            Weapon playerWeapon = Weapon.GetComponent<Weapon>();
            //make it the entity's weapon
            entity.weapon = playerWeapon;
            //destroy pickup through parent method
            base.OnPickUp(entity); 
        }
    }
}
