using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePickup : Pickup
{
    [SerializeField, Range(0, 100), Tooltip("The value to increase weapon damage by when this is picked up")]
    private float damageAmount = 25f;
    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void OnPickUp(HumanoidPawn entity)
    {
        //get the entity that we collided with's health component
        Health entityHealth = entity.GetComponent<Health>();
        //pass the heal amount to their heal function
        entityHealth.Damage(damageAmount);
        //destroy object
        Destroy(gameObject);
    }
}
