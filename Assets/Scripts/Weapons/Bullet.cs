using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [Header("Components")]
    public Pawn owner; //the person who fired this bullet
    private Rigidbody rb; //the rigidbody of the bullet
    [Header("Bullet Settings")]
    public float fireSpeed; //the speed of the bullet
    public float damageDone; //damage done by the bullet, recieved from weapon
    public float lifespan = 1.5f; //the time the bullet has in the scene before it destroys itself

    private void Awake()
    {
        // get the bullet rigidbody
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // set bullet to destroy itself after lifespan has expired
        Destroy(gameObject, lifespan);
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
        if (otherHealth != null)
        {
            //call the damage function on the otherObject's health script to damage them
            //pass in damage done
            otherHealth.Damage(damageDone);
            //call the other object's health onDamage function
            otherHealth.InvokeOnDamage();
        }
        //stop the bullet
        rb.velocity = new Vector3(0f, 0f, 0f);
        //Destroy this bullet
        Destroy(gameObject);
    }
}
