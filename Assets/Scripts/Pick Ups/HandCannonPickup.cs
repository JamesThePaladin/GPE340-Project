using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCannonPickup : Pickup
{
    [SerializeField]
    private GameObject handCannonPrefab;
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
        if (!entity.weapon)
        {
            //get the transform of the weapon spawn point on the asset
            Transform weaponSpawn = entity.GetComponent<Transform>().GetChild(0);
            //name it weapon and spawn it at that points position, rotation, and as a child of it
            GameObject Weapon = Instantiate(handCannonPrefab, weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
            //get the weapon component of Weapon Object
            Weapon entityWeapon = Weapon.GetComponent<Weapon>();
            //make it the entity's weapon
            entity.weapon = entityWeapon;
            //if this entity is the player
            if (entity.CompareTag("Player") == true)
            {
                //set the ammo display
                UIManager.instance.RegisterPlayerAmmo(entity);
            }
            //destroy pickup through parent method
            base.OnPickUp(entity); 
        }
    }
}
