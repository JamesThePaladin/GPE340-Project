using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField, Header("Weapon Prefabs")]
    private GameObject handCannonPrefab;
    [SerializeField]
    private GameObject machineGunPrefab;
    [SerializeField]
    private GameObject shotGunPrefab;
    private List<GameObject> weapons = new List<GameObject>();

    public override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        //add all the prefabs to the weapons list
        weapons.Add(handCannonPrefab);
        weapons.Add(machineGunPrefab);
        weapons.Add(shotGunPrefab);
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
            // choose a random weapon to spawn
            int prefabIndex = Random.Range(0, 2);
            //if the index number is equal to 0, or the hand cannon
            if (prefabIndex == 0)
            {
                //get the transform of the weapon spawn point on the asset
                Transform weaponSpawn = entity.GetComponent<Transform>().GetChild(0);
                //name it weapon and spawn it at that points position, rotation, and as a child of it
                GameObject Weapon = Instantiate(weapons[prefabIndex], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
                //get the weapon component of Weapon Object
                Weapon entityWeapon = Weapon.GetComponent<Weapon>();
                //make it the entity's weapon
                entity.weapon = entityWeapon;
            }
            //else, it is the rifle or machine gun
            else
            {
                //get the transform of the weapon spawn point on the asset
                Transform weaponSpawn = entity.GetComponent<Transform>().GetChild(1);
                //name it weapon and spawn it at that points position, rotation, and as a child of it
                GameObject Weapon = Instantiate(weapons[prefabIndex], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
                //get the weapon component of Weapon Object
                Weapon entityWeapon = Weapon.GetComponent<Weapon>();
                //make it the entity's weapon
                entity.weapon = entityWeapon;
            }
            //if this entity is the player
            if (entity.CompareTag("Player") == true)
            {
                //set the ammo display
                UIManager.instance.RegisterPlayerAmmo(entity);
            }
            //destroy object
            base.OnPickUp(entity);
        }
    }
}
