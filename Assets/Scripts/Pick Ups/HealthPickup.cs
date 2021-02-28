using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    [SerializeField, Range(0, 100), Tooltip("The amount this pickup heals the entity that picks it up.")] 
    private float healAmount;
    // Start is called before the first frame update

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Update();
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
        entityHealth.Heal(healAmount);
        //destroy object
        base.OnPickUp(entity);
    }
}
