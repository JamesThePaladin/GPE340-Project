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
        GameObject parentObject = GameObject.FindGameObjectWithTag("PlayerWeaponSpawn");
        Transform weaponSpawn = parentObject.GetComponent<Transform>();
        int prefabIndex = Random.Range(0, 3); // choose a random weapon to spawn
        GameObject Weapon = Instantiate(weapons[prefabIndex], weaponSpawn.position, weaponSpawn.rotation, weaponSpawn);
        Weapon playerWeapon = Weapon.GetComponent<Weapon>();
        entity.weapon = playerWeapon;
        base.OnPickUp(entity);
    }
}
