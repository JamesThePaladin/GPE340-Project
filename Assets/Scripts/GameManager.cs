using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //variable that holds this instance of the GameManager
    [Header("Enemy Lists")]
    //list to hold all enemies in game
    public List<GameObject> enemies;
    //list of all enemy prefabs to spawn as enemies
    public List<GameObject> enemyPrefabs;
    //list to hold enemy spawners
    public List<GameObject> enemySpawners;
    //list of waypoints for patrolling
    public List<Transform> waypoints;
    [Header("Enemy Spawn Settings")]
    //int for currrent enemies on the map
    public int currentEnemies;
    //int for max enemies on the map
    public int maxEnemies;
    //spawn cooldown for enemy spawns
    public float enemySpawnDelay;
    private void Awake()
    {
        // if instance is empty
        if (instance == null)
        {
            //store THIS instance of the class in the instance variable
            instance = this;
            //keep this instance of game manager when loading new scenes
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //delete the new game manager attempting to store itself, there can only be one.
            Destroy(this.gameObject);
            //display message in the console to inform of its demise
            Debug.Log("Warning: A second game manager was detected and destrtoyed");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject enemy in enemies.ToList()) 
        {
            if (enemy == null) 
            {
                enemies.Remove(enemy);
                currentEnemies--;
            }
        }
    }
}
