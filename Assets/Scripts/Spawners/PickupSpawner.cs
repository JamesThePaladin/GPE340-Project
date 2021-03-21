using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : Spawner
{
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        //if the number of current enemies is less than the number of max enemies
        if (GameManager.instance.currentPickups < GameManager.instance.maxPickups)
        {
            //and if the time is greater than or equal to the next set spawn time
            if (Time.time >= nextSpawnTime)
            {
                //declare a random int between 0 and the max number of enemy prefabs in their list
                int random = Random.Range(0, GameManager.instance.pickupPrefabs.Count);
                //instantiate an enemy using our random int at this objects position
                GameObject item = Instantiate(GameManager.instance.pickupPrefabs[random], tf.position, tf.rotation);
                //name it something meaningful, in this case, the name of the prefab it chose
                //and the number it is in the current enemies count
                item.name = GameManager.instance.pickupPrefabs[random] + "_" + GameManager.instance.currentPickups;
                //add it to the GameManager's list of enemies
                GameManager.instance.pickups.Add(item);
                //set the next spawn time equal to now plus enemy spawn delay
                nextSpawnTime = Time.time + GameManager.instance.pickupSpawnDelay;
                //increment the number of current enemies
                GameManager.instance.currentPickups++;
            }
        }
        base.Update();
    }

    protected override void OnDestroy()
    {
        GameManager.instance.pickupSpawners.Remove(gameObject);
        base.OnDestroy();
    }
}
