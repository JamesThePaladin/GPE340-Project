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
    private GameObject riflePrefab;
    private List<GameObject> weapons = new List<GameObject>();

    // Start is called before the first frame update
    public override void Start()
    {
        //add all the prefabs to the weapons list
        weapons.Add(handCannonPrefab);
        weapons.Add(machineGunPrefab);
        weapons.Add(riflePrefab);
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    protected override void OnPickUp(HumanoidPawn entity)
    {
        // choose a random weapon to spawn
        int prefabIndex = Random.Range(0, 3); 
        //if the index number is equal to 0, or the hand cannon
        if (prefabIndex == 0)
        {
            //find the appropriate spawn point on the entity
            GameObject parentObject = GameObject.Find("SingleHandGunSpawnPoint");
            //get the transform
            Transform weaponSpawn = parentObject.GetComponent<Transform>();
            //name it weapon and spawn it at that points position, rotation, and as a child of it
            GameObject Weapon = Instantiate(weapons[prefabIndex], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
            //get the weapon component of Weapon Object
            Weapon playerWeapon = Weapon.GetComponent<Weapon>();
            //make it the entity's weapon
            entity.weapon = playerWeapon;
        }
        //else, it is the rifle or machine gun
        else 
        {
            //find the appropriate spawn point on the entity
            GameObject parentObject = GameObject.Find("TwoHandedGunSpawnPoint");
            //get the transform
            Transform weaponSpawn = parentObject.GetComponent<Transform>();
            //name it weapon and spawn it at that points position, rotation, and as a child of it
            GameObject Weapon = Instantiate(weapons[prefabIndex], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
            //get the weapon component of Weapon Object
            Weapon playerWeapon = Weapon.GetComponent<Weapon>();
            //make it the entity's weapon
            entity.weapon = playerWeapon;
        }
        base.OnPickUp(entity);
    }
}
