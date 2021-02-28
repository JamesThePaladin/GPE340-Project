using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    private Transform tf; //variable to hold the spawner's transform component
    [SerializeField, Tooltip("Time until the next enemy spawns.")]
    private float nextSpawnTime; //variable to adjust time when the next enemy can spawn
    [SerializeField, Tooltip("Toggle if the spawner is set to move or not.")]
    private bool isMoving = false; //allows the spawn to randomly move
    [SerializeField, Tooltip("Minimum x-axis value the spawner is allowed to move.")]
    private float minX = 10f;
    [SerializeField, Tooltip("Maximum x-axis value the spawner is allowed to move.")]
    private float maxX = 10f;
    [SerializeField, Tooltip("Minimum z-axis value the spawner is allowed to move.")]
    private float minZ = 10f;
    [SerializeField, Tooltip("Maximum z-axis value the spawner is allowed to move.")]
    private float maxZ = 10f;
    [SerializeField, Tooltip("Y value for the random spawner, this is value should remain positive and not randomized.")]
    private float setY = 2f;


    // Start is called before the first frame update
    void Awake()
    {
        tf = GetComponent<Transform>();
    }

    private void Start()
    {
        nextSpawnTime = Time.time + GameManager.instance.enemySpawnDelay;
        GameManager.instance.enemySpawners.Add(gameObject);
    }

    void Update()
    {
        //if the number of current enemies is less than the number of max enemies
        if (GameManager.instance.currentEnemies < GameManager.instance.maxEnemies) 
        {
            //and if the time is greater than or equal to the next set spawn time
            if (Time.time >= nextSpawnTime)
            {
                //declare a random int between 0 and the max number of enemy prefabs in their list
                int random = Random.Range(0, GameManager.instance.enemyPrefabs.Count);
                //instantiate an enemy using our random int at this objects position
                GameObject enemy = Instantiate(GameManager.instance.enemyPrefabs[random], tf.position, tf.rotation);
                //name it something meaningful, in this case, the name of the prefab it chose
                //and the number it is in the current enemies count
                enemy.name = GameManager.instance.enemyPrefabs[random] + "_" + GameManager.instance.currentEnemies;
                //add it to the GameManager's list of enemies
                GameManager.instance.enemies.Add(enemy);
                //set the next spawn time equal to now plus enemy spawn delay
                nextSpawnTime = Time.time + GameManager.instance.enemySpawnDelay;
                //increment the number of current enemies
                GameManager.instance.currentEnemies++;
            }
        }
        if (isMoving) 
        {
            //randomly change position
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            tf.position = new Vector3(randomX, setY, randomZ);
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.enemySpawners.Remove(gameObject);
    }
}
