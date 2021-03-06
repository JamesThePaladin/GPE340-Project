using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    public static GameManager instance; //variable that holds this instance of the GameManager
    [Header("Enemy Data")]
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
    public int currentEnemies = 0;
    //int for max enemies on the map
    public int maxEnemies = 10;
    //spawn cooldown for enemy spawns
    public float enemySpawnDelay = 4f;
    [Header("Pickup Lists")]
    //list of pickups in the game
    public List<GameObject> pickups;
    //list of all pickup prefabs to spawn as pickups
    public List<GameObject> pickupPrefabs;
    //list of to hold pickup spawners
    public List<GameObject> pickupSpawners;
    [Header("Pickup Settings")]
    //current amount of pickups in the game
    public int currentPickups = 0;
    //max amount of pickups in the game
    public int maxPickups = 10;
    //delay in between pickup spawns
    public float pickupSpawnDelay = 4f;
    [Header("Player Data")]
    //player game object
    public GameObject player;
    //player gprefab
    public GameObject playerPrefab;
    //player's boolean for if they are dead or not
    public HumanoidPawn playerPawn;
    //player's health
    public Health Health;
    //if the player is dead or not
    public bool isDead = false;
    //player lives
    public int lives = 3;
    [Header("Weapons Data")]
    public List<GameObject> weapons;
    public bool isGameStart = true;
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
        if (isGameStart) 
        {
            GameStart();
        }
        //for each enemy in the enemies list
        foreach (GameObject enemy in enemies.ToList()) 
        {
            //if it is null
            if (enemy == null) 
            {
                //remove it from the list
                enemies.Remove(enemy);
                //and decrement current enemies
                currentEnemies--;
            }
        }
    }
    /// <summary>
    /// This defines what happens when the player is killed. 
    /// Such as turning off all renderers and triggers, and decrementing the amount of lives.
    /// For now it calls respawn or gameover based on the amount of lives a player has.
    /// That functionality will be changed in the future
    /// </summary>
    public void PlayerDeath() 
    {
        //set our pawn's is dead bool to true, cause they died
        GameManager.instance.isDead = true;
        if (GameManager.instance.playerPawn.weapon != null)
        {
            GameManager.instance.playerPawn.weapon.gameObject.SetActive(false);
        }
        CapsuleCollider _col = GameManager.instance.player.GetComponent<CapsuleCollider>();

        /*get the two different types of renderers and trigger collider on our pawn's children
        note the collider GetComponent only functions correctly because our trigger collider
        is placed before our regular collider in the inspector hierarchy, if the trigger collider
        is moved below our player falls through the ground upon death.*/

        SkinnedMeshRenderer[] _smr = GameManager.instance.player.GetComponentsInChildren<SkinnedMeshRenderer>();
        //disable the meshrenderer on the players visual
        foreach (SkinnedMeshRenderer renderer in _smr)
        {
            renderer.enabled = false;
        }
        //and set the collider to false
        _col.enabled = false;
        //if our lives are less than or equal to zero
        if (lives <= 0)
        {
            GameOver();
        }
        //otherwise
        else
        {
            //call respawn function
            Invoke("Respawn", 3f);
        }
    }

    /// <summary>
    /// Respawn is a reverse operation of PlayerDeath().
    /// Here we enable all renderers and the collider that were previously disabled.
    /// The player is also issued a full heal and moved to (0, 0, 0) in the scene.
    /// </summary>
    public void Respawn() 
    {
        //set the is dead bool for our player to false since they are now alive again
        GameManager.instance.isDead = false;
        //move them to (0, 0, 0)
        GameManager.instance.player.transform.position = new Vector3(2, 1, 7);
        //heal them to full health by calling the method on their Health script
        Health.FullHeal();
        if (GameManager.instance.playerPawn.weapon != null) 
        {
            GameManager.instance.playerPawn.weapon.gameObject.SetActive(true);
        }
        //get their trigger collider and mesh renderers
        SkinnedMeshRenderer[] _smr = GameManager.instance.player.GetComponentsInChildren<SkinnedMeshRenderer>();
        CapsuleCollider _col = GameManager.instance.player.GetComponent<CapsuleCollider>();
        foreach (SkinnedMeshRenderer renderer in _smr)
        {
            //enable skin mesh renderer
            renderer.enabled = true; 
        }
        //enable the trigger collider
        _col.enabled = true;
        //update their health display
        UIManager.instance.RegisterPlayerHealth(playerPawn);
        //update their ammo display
        UIManager.instance.RegisterPlayerAmmo(playerPawn);
        //decrement the amount of lives the player has
        lives--;
        //register player lives
        UIManager.instance.RegisterPlayerLives();
    }

    public void GameStart() 
    {
        //if there isnt a player
        if (!player) 
        {
            //spawn one at vector3 zero with no rotation (or quaternion identity its original rotation)
            GameObject playerOnePawn = Instantiate(playerPrefab, new Vector3(2, 1, 7), Quaternion.identity);
            //set player equal to the newly spawned object
            player = playerOnePawn;
            //set our pawn equal to its pawn
            playerPawn = playerOnePawn.GetComponent<HumanoidPawn>();
            //and our health equal to its health
            Health = playerOnePawn.GetComponent<Health>();
            UIManager.instance.RegisterPlayerHealth(playerPawn);
            UIManager.instance.RegisterPlayerAmmo(playerPawn);
            UIManager.instance.RegisterPlayerLives();
        }
        isGameStart = false;
    }

    public void GameOver() 
    {
        SceneManager.LoadSceneAsync("GameOver");
    }

    public void Win() 
    {
        SceneManager.LoadSceneAsync("WinScreen");
    }

    public void SetGameStart() 
    {
        isGameStart = true;
    }
}
