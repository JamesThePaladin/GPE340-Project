using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    protected Transform tf; //variable to hold the spawner's transform component
    [SerializeField, Tooltip("Time until the next enemy spawns.")]
    protected float nextSpawnTime; //variable to adjust time when the next enemy can spawn
    [SerializeField, Tooltip("Toggle if the spawner is set to move or not.")]
    protected bool isMoving = false; //allows the spawn to randomly move
    [SerializeField, Tooltip("Minimum x-axis value the spawner is allowed to move.")]
    protected float minX = 0f;
    [SerializeField, Tooltip("Maximum x-axis value the spawner is allowed to move.")]
    protected float maxX = 10f;
    [SerializeField, Tooltip("Minimum z-axis value the spawner is allowed to move.")]
    protected float minZ = 0f;
    [SerializeField, Tooltip("Maximum z-axis value the spawner is allowed to move.")]
    protected float maxZ = 10f;
    [SerializeField, Tooltip("Y value for the random spawner, this is value should remain positive and not randomized.")]
    protected float setY = 2f;

    protected virtual void Awake() 
    {
        tf = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isMoving)
        {
            //randomly change position
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            tf.position = new Vector3(randomX, setY, randomZ);
        }
    }

    protected virtual void OnDestroy()
    {
        
    }
}
