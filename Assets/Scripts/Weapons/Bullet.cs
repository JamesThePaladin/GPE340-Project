using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Components")]
    public GameObject owner;
    private Rigidbody rb;
    [Header("Bullet Settings")]
    public float fireSpeed;
    public float damageDone;
    public float lifespan = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // set bullet to destroy itself after lifespan has expired
        Destroy(gameObject, lifespan);

        // get the bullet rigidbody
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // move bullet forward each update frame
        rb.velocity = transform.up * fireSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        //get the object the bullet hit
        GameObject otherObject = other.gameObject;
        //if it has health, make the object take damage
        Health otherHealth = otherObject.GetComponent<Health>();
        if (otherObject != null)
        {
            otherHealth.Damage(damageDone);
        }

        //TODO: Addition things the bullet does when it hits another object

        //Destroy this bullet
        Destroy(gameObject);
    }
}
